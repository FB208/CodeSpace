using System;

using System.Text;

using DotNetty.Buffers;

using DotNetty.Transport.Channels;

namespace DotNettyTest
{
    public class EchoClientHandler : ChannelHandlerAdapter

    {

        //readonly IByteBuffer initialMessage;



        public override void ChannelActive(IChannelHandlerContext context) {
            Console.WriteLine("我是客户端.");
            Console.WriteLine($"连接至服务端{context}.");

            //编码成IByteBuffer,发送至服务端
            string message = "客户端1";
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            IByteBuffer initialMessage = Unpooled.Buffer(messageBytes.Length);
            initialMessage.WriteBytes(messageBytes);

            context.WriteAndFlushAsync(initialMessage);
        } 



        public override void ChannelRead(IChannelHandlerContext context, object message)

        {

            if (message is IByteBuffer byteBuffer)

            {

                Console.WriteLine("Received from server: " + byteBuffer.ToString(Encoding.UTF8));

            }

        }



        public override void ChannelReadComplete(IChannelHandlerContext context) => context.Flush();


        public override void HandlerAdded(IChannelHandlerContext context)
        {
            Console.WriteLine($"服务端{context}上线.");
            
            base.HandlerAdded(context);
        }

        public override void HandlerRemoved(IChannelHandlerContext context)
        {
            Console.WriteLine($"服务端{context}下线.");
            Config.isConnected = false;
            base.HandlerRemoved(context);
        }

        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)

        {

            Console.WriteLine("Exception: " + exception);

            context.CloseAsync();

        }

    }
}
