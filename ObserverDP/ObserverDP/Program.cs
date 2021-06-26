using System;

namespace ObserverDP
{
    class Program
    {
        static void Main(string[] args)
        {
            BlogWriter blogWriter = new BlogWriter();
            BlogReaders reader1 = new BlogReaders("sarah");
            BlogReaders reader2 = new BlogReaders("norah");
            
            
            blogWriter.AddReders(reader1);
            blogWriter.AddReders(reader2);
            
            blogWriter.NotifyReaders("post a new blog");

            blogWriter.NotifyReaders("post another blog");
            
            
        }
    }
}