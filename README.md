# Steps for creating an MVC project using .Net core

Choose the following template in visual studio:

<img width="519" alt="image" src="https://github.com/LITW11/LayoutPages-SelectDemo/assets/159099703/5fcf9011-f56c-438a-ad09-a64e0cdf9511">

Then, make sure to choose .Net 7.0 and to check off "Do not use top-level statements":

<img width="1019" alt="image" src="https://github.com/LITW11/LayoutPages-SelectDemo/assets/159099703/24cfdb13-dd40-451c-8798-52c9f0b16f5b">

Once the project is created, right click on the project file, and click "Edit Project File":

<img width="400" alt="image" src="https://github.com/LITW11/LayoutPages-SelectDemo/assets/159099703/315311ba-246b-4bf5-9b56-6753384118cf">

In there, remove the following line:

```xml
<Nullable>enable</Nullable>
```

and then click save and close that file.

Then, in the HomeController, remove everything except for the following (leave the using statements and the namespace):

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
Then, go into your Views folder, and delete the `Privacy.cshtml` file.

Then, go into the Views/Shared folder and open the _Layout.cshtml file. In there, remove this line from the navbar:

      <li class="nav-item">
          <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
      </li>
If you want to add your own nav link on top, add something like the following:

      <li class="nav-item">
          <a class="nav-link text-dark" asp-controller="PutYourControllerNameHere" asp-action="PutYourActionNameHere">LinkTextToDisplay</a>
      </li>
Then, at the bottom of the layout, remove the footer:

    <footer class="border-top footer text-muted">
        <div class="container">
            &copy; 2024 - WebApplication17 - <a asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
        </div>
    </footer>

## Dealing with nulls in the database

I showed the following extension method to deal with nulls:

    public static class Extensions
    {
        public static T GetOrNull<T>(this SqlDataReader reader, string columnName)
        {
            var value = reader[columnName];
            if (value == DBNull.Value)
            {
                return default(T);
            }

            return (T)value;
        }
    }

Code is here:

https://github.com/LITW11/LayoutPages-SelectDemo/blob/master/WebApplication12/Models/Extensions.cs#L5

We can then use it like so:

https://github.com/LITW11/LayoutPages-SelectDemo/blob/master/WebApplication12/Models/NorthwindDb.cs#L77-L78
