
using DotNetty.Buffers;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DotNettyServiceTest
{
    class Program
    {
        static void Main(string[] args) => RunServerAsync().Wait();

        static async Task RunServerAsync()
        {
            // 主工作线程组，设置为1个线程
            var bossGroup = new MultithreadEventLoopGroup(1);
            // 工作线程组，默认为内核数*2的线程数
            var workerGroup = new MultithreadEventLoopGroup();
            try
            {
                //声明一个服务端Bootstrap，每个Netty服务端程序，都由ServerBootstrap控制，
                //通过链式的方式组装需要的参数
                var bootstrap = new ServerBootstrap();
                bootstrap
                    .Group(bossGroup, workerGroup) // 设置主和工作线程组
                    .Channel<TcpServerSocketChannel>() // 设置通道模式为TcpSocket
                    .Option(ChannelOption.SoBacklog, 100) // 设置网络IO参数等，这里可以设置很多参数，当然你对网络调优和参数设置非常了解的话，你可以设置，或者就用默认参数吧
                    .Option(ChannelOption.SoKeepalive, true)//保持连接
                    .ChildHandler(new ActionChannelInitializer<ISocketChannel>(channel =>
                    {
                        //工作线程连接器 是设置了一个管道，服务端主线程所有接收到的信息都会通过这个管道一层层往下传输
                        //同时所有出栈的消息 也要这个管道的所有处理器进行一步步处理
                        IChannelPipeline pipeline = channel.Pipeline;

                        //业务handler ，这里是实际处理业务的Handler
                        pipeline.AddLast(new HelloServerHandler());
                    }));

                // bootstrap绑定到指定端口的行为 就是服务端启动服务，同样的Serverbootstrap可以bind到多个端口
                IChannel boundChannel = await bootstrap.BindAsync(3399);
                Console.WriteLine("服务启动");

                Console.ReadLine();
                //关闭服务
                await boundChannel.CloseAsync();
            }
            finally
            {
                //释放工作组线程
                await Task.WhenAll(
                    bossGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)),
                    workerGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)));
            }
        }
    }

    public class HelloServerHandler : ChannelHandlerAdapter //管道处理基类，较常用
    {
        public override bool IsSharable => true;//标注一个channel handler可以被多个channel安全地共享。

        //  重写基类的方法，当消息到达时触发，这里收到消息后，在控制台输出收到的内容，并原样返回了客户端
        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            if (message is IByteBuffer buffer)
            {
                Console.WriteLine("从客户端接收: " + buffer.ToString(Encoding.UTF8));
            }

            //编码成IByteBuffer,发送至客户端
            string msg = "服务端从客户端接收到内容后返回，我是服务端";
            byte[] messageBytes = Encoding.UTF8.GetBytes(msg);
            IByteBuffer initialMessage = Unpooled.Buffer(messageBytes.Length);
            initialMessage.WriteBytes(messageBytes);

            context.WriteAsync(initialMessage);//写入输出流
        }

        // 输出到客户端，也可以在上面的方法中直接调用WriteAndFlushAsync方法直接输出
        public override void ChannelReadComplete(IChannelHandlerContext context) => context.Flush();

        //捕获 异常，并输出到控制台后断开链接，提示：客户端意外断开链接，也会触发
        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        {
            Console.WriteLine("异常: " + exception);
            context.CloseAsync();
        }

        //客户端连接进来时
        public override void HandlerAdded(IChannelHandlerContext context)
        {
            Console.WriteLine($"客户端{context}上线.");
            base.HandlerAdded(context);
        }

        //客户端下线断线时
        public override void HandlerRemoved(IChannelHandlerContext context)
        {
            Console.WriteLine($"客户端{context}下线.");
            base.HandlerRemoved(context);
        }

        //服务器监听到客户端活动时
        public override void ChannelActive(IChannelHandlerContext context)
        {
            Console.WriteLine($"客户端{context.Channel.RemoteAddress}在线.");
            base.ChannelActive(context);
        }

        //服务器监听到客户端不活动时
        public override void ChannelInactive(IChannelHandlerContext context)
        {
            Console.WriteLine($"客户端{context.Channel.RemoteAddress}离线了.");
            base.ChannelInactive(context);
        }

    }

}
