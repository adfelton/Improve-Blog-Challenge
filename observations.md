Notes / Observations regarding the tasks.
---
I ended up using VS2019 rather than VScode as a personal preference.

I managed to cover tasks 1, 2, 3 and 4, as well as some refactoring etc in keeping with task 7, but didn't have the time to get to 5 and 6. 

Regarding Task 1, I did actually come up with a solution for replacing the id with the slug completely just to see if it was possible. As expected though, there are a ton of issues with this route. The Id/slug route would obviously be my suggested solution and is generally best practice.

Regarding Task 2, I presume the intention with the background colour would be to store it within the post entity in the database, which is obviously not possible with the dummy data, so I just added a default value after moving the logic into the API.

Regarding Task 4, loading the comments for all posts just to get the count significantly impacts the load time for the Posts/Index method and I would likely add server side pagination to this page to mitigate it (This would be advisable on a page like this anyway for scaling). Additionally, with access to the actual source database (obviously not possible with dummy data) I would probably look at providing the comment count as part of the Post object.

There's currently no authentication on the API, which is definitely not good enough for a live product. I would advise implementing token authentication.

---------------------------------------------------------------------------------------------------------------------

Main Additions & Changes
---
API
-
Added ConstHelper.cs and StringHelper.cs to handle Sluggification. These methods were lifted from the web as I see no reason to re-invent the wheel. Added the source url to the cs files for reference. I would consider reworking these into a String extension.


Frontend
-
Added APIUrl to appsettings.json and created AppSettings.cs to store the API Url

Added BlogService.cs to handle business logic and clean up the controllers.

Changed URL's of featured and not-so-featured items on home index to point straight to details page. It was pointing to post index before which didn't seem intuitive.

Rewrote the Home Controller and View to use a View Model rather than View Data

