using System;
namespace MultiThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            TPLOperation operation = new TPLOperation();
            operation.TaskParallel();
        }
    }
}