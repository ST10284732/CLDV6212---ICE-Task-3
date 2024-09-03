using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjTreasureHunt.Services
{ 
        public class TableStorage
        {
            private readonly TableClient _prodTableClient; //for prod table
            private readonly TableClient _orderTableClient; //for transaction table
            private readonly TableClient _userTableClient; //for user table 

            public TableStorage(string connectionString) //constructor that will connect to Azure
            {
                //assign table variables above to the relevant azure tables 
                _prodTableClient = new TableClient(connectionString, "Items");
                _orderTableClient = new TableClient(connectionString, "Findings");
                _userTableClient = new TableClient(connectionString, "Members");
            }
        }
}
