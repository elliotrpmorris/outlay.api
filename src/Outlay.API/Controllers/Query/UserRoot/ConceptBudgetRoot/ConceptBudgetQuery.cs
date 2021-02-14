// <copyright file="ConceptBudgetQuery.cs" company="Outlay">
// Copyright (c) Outlay. All rights reserved.
// </copyright>

namespace Outlay.API.Controllers.Query.UserRoot.ConceptBudgetRoot
{
    using GraphQL.Types;
    using Outlay.API.Controllers.Query.UserRoot.Types;
    using Outlay.Domain.Data.Budget;

    public class ConceptBudgetQuery : ObjectGraphType<ConceptBudgetQueryContext>
    {
        public ConceptBudgetQuery(
            IConceptBudgetReader<ConceptBudget> conceptBudgetReader)
        {
            this.Field<ConceptBudgetType, ConceptBudget?>()
                .Name("info")
                .Description("Concept budget information")
                .ResolveAsync(context => conceptBudgetReader.GetConceptBudgetByIdAsync(
                    context.Source.BudgetId));
        }
    }
}
