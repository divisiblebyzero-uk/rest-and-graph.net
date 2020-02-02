using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using GraphQL.Types;
using RestAndGraphNet.entities;

namespace RestAndGraphNet.graphql
{
    public class CountryType:ObjectGraphType<Country>
    {
        public CountryType()
        {
            Name = "Country";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("The Id of the Country");
            Field(x => x.Name).Description("The name of the Country");
            Field(x => x.Language).Description("The language of the Country");

        }
    }
}
