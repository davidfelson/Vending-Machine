using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Capstone.Classes
{

    //    todo Make Method and Streamwriter
    // Method: LogTransactions()
    //-make and array to log below info each time an item is despensed

    //- exports using StreamWriter
    //    dispenses log.txt with datetimenow, product purchased (derived from Product Class), slot location(derived from Product Class), starting balance(derived from Money Class), remaining balance(derived from Money Class)
    //    ...called in Menu when user selects Exit

    public class Audit
    {
        public 


        string filePath = @"..\..\..\..\Log.txt";

        public void AuditLog(string[] components)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                if  //if FeedMoney method runs
                    { 
                    writer.WriteLine($"{DateTime.UtcNow}");
                    }
            }
        }
      

	
    }        
    


}





