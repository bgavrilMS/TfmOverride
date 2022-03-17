using System;

namespace FakeMsal
{
    public class FakeMsal
    {
        public string GetTfm()
        {
#if NETCOREAPP2_1
            return "netcoreapp2.1";
#elif NET5_0
        return "net5.0-windows10.x";
#elif NETSTANDARD1_3
        return "netstandard1.3";        
#endif
            throw new NotImplementedException("I don't know this TFM");

        }
    }
}
