﻿using Havalan.Domain.Base;
using Havalan.Domain.Common;

namespace Havalan.Domain.Comments;
public class Comments : BaseEntity
{
    private Comments() { }

    public long PostId { get; private set; }
    public string UserName { get; private set; }
    public string Text { get; private set; }


    public Comments(long postId, string userName, string text)
    {
        CheckInputs(userName, text);
        PostId = postId;
        UserName = userName;
        Text = text;
    }

    private void CheckInputs(string userName, string text)
    {
        NullOrEmptyException.CheckString(userName, nameof(userName));
        NullOrEmptyException.CheckString(text, nameof(text));
    }
}