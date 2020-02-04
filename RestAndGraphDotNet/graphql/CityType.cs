using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using RestAndGraphNet.entities;

namespace RestAndGraphNet.graphql
{
    public class CityType:ObjectGraphType<City>
    {
        public CityType()
        {
            Name = "City";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("The Id of the city");
            Field(x => x.Name).Description("The name of the city");
            Field(x => x.Size).Description("The size of the city");
            Field(
                x => x.Country,
                type: typeof(CountryType)
                ).Description("The country of the city");

        }
    }
}
