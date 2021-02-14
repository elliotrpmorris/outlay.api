// <copyright file="ConceptBudgetType.cs" company="Outlay">
// Copyright (c) Outlay. All rights reserved.
// </copyright>

namespace Outlay.API.Controllers.Query.UserRoot.Types
{
    using System;
    using GraphQL.Types;
    using Outlay.Domain.Data.Budget;

    public class ConceptBudgetType : ObjectGraphType<ConceptBudget>
    {
        public ConceptBudgetType()
        {
            this.Field<IdGraphType, Guid>("id")
                .Description("The user identifier.")
                .Resolve(context => context.Source.Id);

            this.Field(p => p.Items)
                .Name("items")
                .Description("The user identifier.");

            this.Field(p => p.ConceptName)
               .Name("conceptName")
               .Description("The concept name");
        }
    }
}
