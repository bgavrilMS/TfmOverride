using System;

namespace ClassLibrary1
{
    public class Lib
    {
        public string GetFramework()
        {
            FakeMsal.FakeMsal fakeMsalClient = new FakeMsal.FakeMsal();
            return fakeMsalClient.GetTfm();
        }


    }
}
