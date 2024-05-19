using CoreNodeModels;
using Dynamo.Graph.Nodes;
using Dynamo.Utilities;
using ProtoCore.AST.AssociativeAST;
using System.Collections.Generic;
using System.Windows;

namespace Styles
{
    [NodeName("TextBlock Styles")]
    [NodeCategory("Styles")]
    [NodeDescription("An example drop down node.")]
    [IsDesignScriptCompatible]
    public class TextBlock : DSDropDownBase
    {
        public TextBlock() : base("item") { }

        protected override SelectionState PopulateItemsCore(string currentSelection)
        {
            Items.Clear();

            var newItems = new List<DynamoDropDownItem>()
            {
                new DynamoDropDownItem("Tywin", 0),
                new DynamoDropDownItem("Cersei", 1),
                new DynamoDropDownItem("Hodor",2)
            };

            Items.AddRange(newItems);
            // Pre-select first element
            SelectedIndex = 0;

            return SelectionState.Restore;
        }

        public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> inputAstNodes)
        {
            // Build an AST node for the type of object contained in your Items collection.

            if (Items.Count == 0 || SelectedIndex == -1)
            {
                MessageBox.Show("No items");
                return new[] { AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(0), AstFactory.BuildNullNode()) };
            }

            var intNode = AstFactory.BuildIntNode((int)Items[SelectedIndex].Item);
            var assign = AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(0), intNode);

            return new List<AssociativeNode> { assign };
        }
    }
}