using System;
using System.Security.Cryptography.X509Certificates;

namespace Berzerkers
{
    public interface IRandomProvider
    {

        int ProvideRandom();
      


    }

}
