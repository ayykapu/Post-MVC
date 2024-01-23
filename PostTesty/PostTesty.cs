using Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Post_MVC.Controllers;
using Post_MVC.Models;

namespace laboratorium_9___test;

public class PostControllerTest
{
    private PostController _controller;
    private IPostService _postService;



    public PostControllerTest()
    {

        _postService.Add(new Post() { PostAuthor = "Test1", PostContent = "Test1", PostDate = DateTime.Now, TagId = 1 });
        _postService.Add(new Post() { PostAuthor = "Test2", PostContent = "Test2", PostDate = DateTime.Now, TagId = 2 });
        _postService.Add(new Post() { PostAuthor = "Test3", PostContent = "Test3", PostDate = DateTime.Now, TagId = 3 });
        _postService.Add(new Post() { PostAuthor = "Test4", PostContent = "Test4", PostDate = DateTime.Now, TagId = 4 });
        _postService.Add(new Post() { PostAuthor = "Test5", PostContent = "Test5", PostDate = DateTime.Now, TagId = 5 });


    }

    [Fact]
    public void IndexWithoutTag()
    {
        var result = _controller.Index();
        Assert.IsType<ViewResult>(result);

        var view = result as ViewResult;
        Assert.IsType<List<Post>>(view.Model);
        List<Post>? list = view.Model as List<Post>;
        Assert.NotNull(list);
        Assert.Equal(_postService.FindAll().Count, list.Count);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void IndexWithTag(int id)
    {
        var result = _controller.Index(id);
        Assert.IsType<ViewResult>(result);

        var view = result as ViewResult;
        Assert.IsType<List<Post>>(view.Model);
        List<Post>? list = view.Model as List<Post>;
        Assert.NotNull(list);
        Assert.Equal(_postService.FindByTag(id).Count, list.Count);
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 2)]
    [InlineData(3, 2)]
    public void PagedIndexWithoutTag(int page, int size)
    {
        var result = _controller.PagedIndex(0, page, size);
        Assert.IsType<ViewResult>(result);

        var view = result as ViewResult;
        Assert.IsType<PagingList<Post>>(view.Model);
        PagingList<Post>? pagingList = view.Model as PagingList<Post>;
        Assert.NotNull(pagingList);
        Assert.Equal(_postService.FindPage(page, size, _postService.FindAll()).Data.Count(), pagingList.Data.Count());
    }

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(2, 2, 3)]
    [InlineData(3, 1, 1)]
    [InlineData(4, 1, 4)]
    [InlineData(5, 1, 2)]

    public void PagedIndexWithTag(int id, int page, int size)
    {
        var result = _controller.PagedIndex(id, page, size);
        Assert.IsType<ViewResult>(result);

        var view = result as ViewResult;
        Assert.IsType<PagingList<Post>>(view.Model);
        PagingList<Post>? pagingList = view.Model as PagingList<Post>;
        Assert.NotNull(pagingList);
        Assert.Equal(_postService.FindPage(page, size, _postService.FindByTag(id)).Data.Count(), pagingList.Data.Count());
    }

    [Fact]
    public void Create()
    {
        Post model = new Post() { PostAuthor = "Test", PostContent = "Test", PostDate = DateTime.Now, TagId = 1 };
        var prevCount = _postService.FindAll().Count;
        var result = _controller.Create(model);
        Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal(prevCount + 1, _postService.FindAll().Count());
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void UpdateForExisingPost(int id)
    {
        var post = _postService.FindById(id);
        Assert.NotNull(post);
        post.PostContent = "Update";
        post.PostAuthor = "Update";
        _controller.Update(post);
        var updatedPost = _postService.FindById(id);
        Assert.NotNull(updatedPost);
        Assert.Equal("Update", updatedPost.PostAuthor);
        Assert.Equal("Update", updatedPost.PostContent);
    }

    [Fact]
    public void UpdateForNonExisingPost()
    {
        Post newPost = new Post() { PostId = 6, PostAuthor = "Test" };
        var result = _controller.Update(newPost);
        Assert.IsType<RedirectToActionResult>(result);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void DetailsForExisingPost(int id)
    {
        var result = _controller.Details(id);
        Assert.IsType<ViewResult>(result);
        var view = result as ViewResult;
        Assert.NotNull(view);
        Assert.IsType<Post>(view.Model);
        Post? model = view.Model as Post;
        Assert.NotNull(model);
        Assert.Equal(id, model.PostId);
    }

    [Fact]
    public void DetailsForNonExisingPost()
    {
        var result = _controller.Details(6);
        Assert.IsType<NotFoundResult>(result);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void DeleteForExisingPost(int id)
    {
        var oldCount = _postService.FindAll().Count;
        Post? post = _postService.FindById(id);
        Assert.NotNull(post);
        _controller.Delete(post);
        Assert.Equal(oldCount - 1, _postService.FindAll().Count());
    }

    [Fact]
    public void DeleteForNonExisingPost()
    {
        int oldCount = _postService.FindAll().Count;
        Post post = new Post() { PostId = 1000, PostAuthor = "Post", PostContent = "Post" };
        _controller.Delete(post);
        Assert.Equal(oldCount, _postService.FindAll().Count());
    }

}