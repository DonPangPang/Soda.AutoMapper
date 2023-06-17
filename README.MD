# Soda.AutoMapper

基于 `AutoMapper` 仅在调用上做了简化.

按照通常的调用方式调用`service.AddAutoMapper()`和配置即可.

添加 `app.InitSodaMapper()` 使该程序初始化.

例子：

```csharp
var entity = obj.MapTo<Entity>();
```

```csharp
obj.Map<Dto>(entity);
```

```csharp
var data = await Db.Blogs.Map<Blog, VBlog>().ToListAsync();
```
