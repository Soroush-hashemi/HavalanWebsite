using Havalan.Domain.Base;
using Havalan.Domain.Common;

namespace Havalan.Domain.TrendingNews;
public class TrendingNew : BaseEntity
{
    private TrendingNew() { }

    public string Title { get; set; }

    public TrendingNew(string title)
    {
        CheckInput(title);
        Title = title;
    }

    public void Edit(string title)
    {
        CheckInput(title);
        Title = title;
    }

    public void CheckInput(string title)
    {
        NullOrEmptyException.CheckString(title, nameof(title));
    }
}