using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace TransactionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //TransactionScope 事务范围
                using (TransactionScope scope = new TransactionScope())
                {

                    //Create an enlistment object 创建登记对象
                    myEnlistmentClass myElistment = new myEnlistmentClass();

                    //Enlist on the current transaction with the enlistment object 使用登记对象在当前事务上登记。
                    Transaction.Current.EnlistVolatile(myElistment, EnlistmentOptions.None);

                    //Perform transactional work here. 在此执行事务性工作
                    ILog log = log4net.LogManager.GetLogger("TestLogger.TestInherit");

                    log.Info("Before TransactionScope Commit");

                    //Call complete on the TransactionScope based on console input  调用 基于Consle输入的TransactionScope的 Complete方法 
                    ConsoleKeyInfo c;
                    while (true)
                    {
                        Console.Write("Complete the transaction scope? [Y|N] ");
                        c = Console.ReadKey();
                        Console.WriteLine();

                        if ((c.KeyChar == 'Y') || (c.KeyChar == 'y'))
                        {
                            scope.Complete();
                            break;
                        }
                        else if ((c.KeyChar == 'N') || (c.KeyChar == 'n'))
                        {
                            break;
                        }
                    }
                }
            }
            catch (System.Transactions.TransactionException ex)
            {
                Console.WriteLine(ex);
            }
            catch
            {
                Console.WriteLine("Cannot complete transaction");
                throw;
            }
        }


        private static void Transfer(string accountFrom, string accountTo, double amount)
        {
            Transaction originalTransaction = Transaction.Current;
            CommittableTransaction ct = new CommittableTransaction();
            try
            {
                Transaction.Current = ct;
                //Withdraw(accountFrom, amount);
                //Deposit(accountTo, amount);
                ct.Commit();
            }
            catch
            {
                ct.Rollback();
                throw;
            }
            finally
            {
                Transaction.Current = originalTransaction;
                ct.Dispose();
            }
        }
    }


    public class myEnlistmentClass : IEnlistmentNotification
    {
        public void Prepare(PreparingEnlistment preparingEnlistment)
        {
            Console.WriteLine("Prepare notification received");

            //Perform transactional work
            ILog log = log4net.LogManager.GetLogger("TestLogger.TestInherit");

            log.Info("Prepare");

            //If work finished correctly, reply prepared
            preparingEnlistment.Prepared();

            // otherwise, do a ForceRollback
            //preparingEnlistment.ForceRollback();
        }

        public void Commit(Enlistment enlistment)
        {
            Console.WriteLine("Commit notification received");

            //Do any work necessary when commit notification is received
            ILog log = log4net.LogManager.GetLogger("TestLogger.TestInherit");

            log.Info("Commit");

            //Declare done on the enlistment
            enlistment.Done();
        }

        public void Rollback(Enlistment enlistment)
        {
            Console.WriteLine("Rollback notification received");

            //Do any work necessary when rollback notification is received
            ILog log = log4net.LogManager.GetLogger("TestLogger.TestInherit");

            log.Info("Roolback");

            //Declare done on the enlistment
            enlistment.Done();
        }

        public void InDoubt(Enlistment enlistment)
        {
            Console.WriteLine("In doubt notification received");

            //Do any work necessary when indout notification is received
            ILog log = log4net.LogManager.GetLogger("TestLogger.TestInherit");
            log.Info("InDoubt");

            //Declare done on the enlistment
            enlistment.Done();
        }
    }




}
