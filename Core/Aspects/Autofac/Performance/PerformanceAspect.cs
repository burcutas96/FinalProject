using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Core.Aspects.Autofac.Performance
{
    //Eğer sistemin performans zaafiyeti olduğunda bizi uyarmasını istiyorsak Performance Aspectinden yararlanırız. 
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;  //Metodun toplamda çalışma süresi kaç olduktan sonra hata verilmesini istiyorsak onu interval'e göndeririz.
        private Stopwatch _stopwatch; //Kronometre görevi görür.

        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }


        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();  //Metodun başında kronometreyi başlattık.
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                //Metotta geçen süre aşıldığı taktirde bize uyarının nasıl verilmesini istiyorsak burayı o şekilde doldurmalıyız.
                //Mesela aşağıda consola loglama yapılmış ama isterseniz mail de gönderebilirsiniz.
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
            }
            _stopwatch.Reset();
        }
    }
}
