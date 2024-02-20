
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

Console.Clear();

using var context = new BlogDataContext();

var postsWithTagsCount = context.postWithTagsCount.ToList();