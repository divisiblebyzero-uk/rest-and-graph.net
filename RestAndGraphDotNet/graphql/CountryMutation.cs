using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using RestAndGraphNet.entities;

namespace RestAndGraphNet.graphql
{
    public class CountryMutation : ObjectGraphType
    {
        public CountryMutation(DataContext dataContext)
        {
            Name = "Country Mutation";

            Field<CountryType>(
                name: "CreateCountry",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                        {Name = "name", Description = "The Name of the Country"},
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                        {Name = "language", Description = "The Language of the Country"}
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
        }
    }
}
