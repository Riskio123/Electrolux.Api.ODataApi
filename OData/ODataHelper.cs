using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.OData.UriParser;

namespace Electrolux.Api.ODataApi.OData
{
    public class ODataHelper
    {
        public ODataFilter ConvertODataToBackendQueryFilter(FilterClause filterClause)
        {
            if (filterClause == null)
                throw new ArgumentNullException(nameof(filterClause));

            
            var binaryOperatorNode = filterClause.Expression as BinaryOperatorNode;
            if (binaryOperatorNode == null)
                throw new NotSupportedException("Only binary operators are supported.");

            string fieldName;
            if (binaryOperatorNode.Left is ConvertNode convertNode)
            {
                var propertyNode = convertNode.Source as SingleValuePropertyAccessNode;
                if (propertyNode == null)
                    throw new NotSupportedException("Converted left side must be a property.");

                fieldName = propertyNode.Property.Name;
            }
            else if (binaryOperatorNode.Left is SingleValuePropertyAccessNode singleValueNode)
            {
                var propertyNode = singleValueNode;
                fieldName = propertyNode.Property.Name;
            }
            else
            {
                throw new NotSupportedException($"Unsupported left node type: {binaryOperatorNode.Left.GetType()}");
            }

            //var propertyNode = binaryOperatorNode.Left as s;
            //if (propertyNode == null)
            //    throw new NotSupportedException("Left side must be a property.");
            
            //string fieldName = propertyNode.Property.Name;

            
            var operatorKind = binaryOperatorNode.OperatorKind;

            
            var constantNode = binaryOperatorNode.Right as ConstantNode;
            if (constantNode == null)
                throw new NotSupportedException("Right side must be a constant.");

            var fieldValue = constantNode.Value.ToString();

            
            string operatorType = operatorKind switch
            {
                BinaryOperatorKind.Equal => "eq",
                BinaryOperatorKind.NotEqual => "ne",
                BinaryOperatorKind.GreaterThan => "gt",
                BinaryOperatorKind.GreaterThanOrEqual => "gte",
                BinaryOperatorKind.LessThan => "lt",
                BinaryOperatorKind.LessThanOrEqual => "lte",
                _ => throw new NotSupportedException($"Operator '{operatorKind}' is not supported.")
            };

            return new ODataFilter
            {
                Field = fieldName,
                Operator = operatorType,
                Value = fieldValue
            };
        }

    }
}
