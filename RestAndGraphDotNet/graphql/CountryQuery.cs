using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using RestAndGraphNet.entities;

namespace RestAndGraphNet.graphql
{
    public class CountryQuery : ObjectGraphType
    {
        public CountryQuery(DataContext dataContext)
        {
            Name = "Country Query";

            Field<CountryType>(
                "Country",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> {Name = "id", Description = "The Id of the Country"}),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var country = dataContext.Countries.FirstOrDefault(i => i.Id == id);
                    return country;
                });
            Field<ListGraphType<CountryType>>(
                "Countries",
                resolve: context => dataContext.Countries.OrderBy(c => c.Name)
                );
        }
    }
}
