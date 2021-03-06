﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RestAndGraphNet.entities;

namespace RestAndGraphNet.graphql
{
    public class AppSchema : Schema
    {
        public AppSchema(AppQuery countryQuery, AppMutation countryMutation)
        {
            Query = countryQuery;
            Mutation = countryMutation;
        }
    }
}
