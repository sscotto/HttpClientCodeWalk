# HttpClientCodeWalk

Small repo to understand the correct way of using the class HttpClient from .Net.

The repo has three controllers.

CatFactController and CatFactControllerWithService with a correct usage of the HttpClient.

WrongCatFactController with a wrong implementation.
The issue with this implementation is that is creating a new HttpClient per-request and is disposing it, in this case what will happen is that .net is releasing everything and the OS understand that needs to release the port.
But the port will not be release right away, it will switch to the status TIME_WAIT for 5 minutes (or so), so when you call the endpoint again is going to use another port, leading to port exhaustion issue.


Check on program.cs to see how the httpclient is register on the DI container.
