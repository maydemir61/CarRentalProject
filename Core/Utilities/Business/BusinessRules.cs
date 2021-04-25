using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {

        public static IResult Run(params IResult[] results)
        {

            foreach (IResult result in results)
            {
                if (!result.Succes)
                {
                    return result;
                }
                
            }
            return null;

            
        }

    }
}
