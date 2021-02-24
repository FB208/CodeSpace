using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Handlers.Logging;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;

namespace DotNettyTest
{
    class Program
    {
        static async Task RunClientAsync()
        {
            var group = new MultithreadEventLoopGroup();
            try
            {
                var bootstrap = new Bootstrap();
                bootstrap
                    .Group(group)
                    .Channel<TcpSocketChannel>()
                    .Option(ChannelOption.TcpNodelay, true)
                    .Handler(
                        new ActionChannelInitializer<ISocketChannel>(
                            channel =>
                            {
                                IChannelPipeline pipeline = channel.Pipeline;
                                pipeline.AddLast(new LoggingHandler());
                                //pipeline.AddLast("framing-enc", new LengthFieldPrepender(2));
                                //pipeline.AddLast("framing-dec", new LengthFieldBasedFrameDecoder(ushort.MaxValue, 0, 2, 0, 2));
                                pipeline.AddLast("echo", new EchoClientHandler());

                            }));



                IChannel clientChannel = await bootstrap.ConnectAsync(new IPEndPoint(IPAddress.Parse("192.168.18.126"), 3399));

                if (clientChannel.Active)
                {
                    Config.isConnected = true;
                }


                // 建立死循环，类同于While(true)
                long index = 1;
                while (true)
                {
                    //if (index==16380)
                    //{

                    //}
                    string message = index+ "一二三四五六七八九十一二三四五六七八九十一二三四五六七八九十一二三四五六七八九十一二三四五六七八九十一二三四五六七八九十一二三四五六七八九十一二三四五六七八九十一二三四五六七八九十一二三四五六七八九十一二三四五六七八九十一二三四五六七八九十一二三四五六七八九十一二三四五六七八九十一二三四五六七八九十一二三四五六七八九十一二三四五六七八九十一二三四五六七八九十一二三四五六七八九十一二三四五六七八九十";
                    byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                    IByteBuffer initialMessage = Unpooled.Buffer(1024);
                    initialMessage.WriteBytes(messageBytes);
                    await clientChannel.WriteAndFlushAsync(initialMessage);
                    index++;
                    Thread.Sleep(10);
                }
                for (; ; ) // (4)

                {

                    Console.WriteLine("input you data:");

                    // 根据设置建立缓存区大小

                    IByteBuffer initialMessage = Unpooled.Buffer(1024); // （1）

                    string r = Console.ReadLine();

                    // 将数据流写入缓冲区

                    initialMessage.WriteBytes(Encoding.UTF8.GetBytes(r ?? throw new InvalidOperationException())); // (2)

                    // 将缓冲区数据流写入到管道中

                    await clientChannel.WriteAndFlushAsync(initialMessage); // (3)

                    if (r.Contains("bye"))

                        break;
                    if (r.Contains("recon"))
                    {
                        RunClientAsync().Wait();
                        break;
                    }

                }



                Console.WriteLine("byebye");





                await clientChannel.CloseAsync();

            }

            finally

            {

                await group.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1));

            }

        }



        static void Main()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("进入");
                        if (!Config.isConnected)
                        {
                            Console.WriteLine("执行");
                            RunClientAsync();//.Wait();
                            Console.WriteLine("执行完");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("异常" + ex.Message);

                    }
                    Thread.Sleep(5000);
                }

            }, TaskCreationOptions.LongRunning);

            Console.ReadKey();

        }
    }
}
