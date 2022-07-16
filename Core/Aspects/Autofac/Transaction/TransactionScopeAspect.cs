using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    //Bir metotta herhangi bir işlemin hatalı olması durumunda bütün o işlemlerin geri alınmasını sağlar.
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (Exception e)
                {
                    transactionScope.Dispose(); //İşlemler veri tabanı belleğinde olur. Eğer try hata verirse işlemleri geri alır.
                    throw;
                }
            }
        }
    }
}
