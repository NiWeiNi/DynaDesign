using CoreNodeModels;
using Dynamo.Graph.Nodes;
using Dynamo.Utilities;
using ProtoCore.AST.AssociativeAST;
using System.Collections.Generic;

namespace Styles
{
    [NodeName("TextBlock Styles")]
    [NodeCategory("Styles.TextBlock")]
    [NodeDescription("Styles for TextBlock")]
    [IsDesignScriptCompatible]
    public class TextBlock : DSDropDownBase
    {
        public TextBlock() : base("item") { }

        protected override SelectionState PopulateItemsCore(string currentSelection)
        {
            Items.Clear();

            var newItems = new List<DynamoDropDownItem>()
            {
                new DynamoDropDownItem("MaterialDesignBodySmallTextBlock", "MaterialDesignBodySmallTextBlock"),
                new DynamoDropDownItem("MaterialDesignBodyMediumTextBlock", "MaterialDesignBodyMediumTextBlock"),
                new DynamoDropDownItem("MaterialDesignBodyLargeTextBlock","MaterialDesignBodyLargeTextBlock")
            };

            Items.AddRange(newItems);
            SelectedIndex = 0;

            return SelectionState.Restore;
        }

        public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> inputAstNodes)
        {
            // Build an AST node for the type of object contained in your Items collection.
            if (Items.Count == 0 || SelectedIndex == -1)
            {
                return new[] { AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(0), AstFactory.BuildNullNode()) };
            }

            var stringNode = AstFactory.BuildStringNode(Items[SelectedIndex].Item.ToString());
            var assign = AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(0), stringNode);

            return new List<AssociativeNode> { assign };
        }
    }
}