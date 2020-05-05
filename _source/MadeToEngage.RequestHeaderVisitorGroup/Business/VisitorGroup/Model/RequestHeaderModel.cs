using System.ComponentModel.DataAnnotations;
using EPiServer.Personalization.VisitorGroups;
using EPiServer.Web.Mvc.VisitorGroups;

namespace MadeToEngage.RequestHeaderVisitorGroup.Business.VisitorGroup.Model
{
    public class RequestHeaderModel : CriterionModelBase
    {
        [Required]
        public string Key { get; set; }

        [Required, DojoWidget(SelectionFactoryType = typeof(EnumSelectionFactory))]
        public RequestHeaderValueCondition Condition { get; set; }
        public string Value { get; set; }

        public override ICriterionModel Copy()
        {
            return base.ShallowCopy();
        }
    }

    public enum RequestHeaderValueCondition
    {
        Exists,
        HasValue
    }
}
