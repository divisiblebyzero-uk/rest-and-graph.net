using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using RestAndGraphNet.entities;

namespace RestAndGraphNet.graphql
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(DataContext dataContext)
        {
            Name = "Query";

            Field<CountryType>(
                "Country",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id", Description = "The Id of the Country" }),
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


            Field<CityType>(
                "City",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id", Description = "The Id of the city" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var city = dataContext.Cities.Include(c => c.Country).FirstOrDefault(i => i.Id == id);
                    return city;
                });
            Field<ListGraphType<CityType>>(
                "Cities",
                resolve: context => dataContext.Cities.Include(c => c.Country).OrderBy(c => c.Name)
            );


        }
    }
}
