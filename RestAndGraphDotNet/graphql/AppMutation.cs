using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using RestAndGraphNet.entities;

namespace RestAndGraphNet.graphql
{
    public class AppMutation : ObjectGraphType
    {
        public AppMutation(DataContext dataContext)
        {
            Name = "Mutation";

            Field<CountryType>(
                name: "CreateCountry",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                        { Name = "name", Description = "The Name of the Country" },
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                        { Name = "language", Description = "The Language of the Country" }
                ),
                resolve: context =>
                {
                    var name = context.GetArgument<String>("name");
                    var language = context.GetArgument<String>("language");
                    var country = new Country(name, language);
                    dataContext.Countries.Add(country);
                    dataContext.SaveChanges();
                    return country;
                });

            Field<CityType>(
                name: "CreateCity",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                        { Name = "name", Description = "The Name of the Country" },
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                        { Name = "size", Description = "The Language of the Country" },
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    { Name = "countryId", Description = "The id of the country" }
                ),
                resolve: context =>
                {
                    var name = context.GetArgument<String>("name");
                    var size= context.GetArgument<String>("size");
                    var countryId = context.GetArgument<int>("countryId");
                    var country = dataContext.Countries.FirstOrDefault(c => c.Id == countryId);
                    var city = new City(name, size, country);
                    dataContext.Cities.Add(city);
                    dataContext.SaveChanges();
                    return city;
                });
        }
    }
}
