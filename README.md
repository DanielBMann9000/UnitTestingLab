Unit testing lab
========

I've been having to do some unit testing training lately, so I threw together a really simple lab exercise to help out. The ultimate goal here is to demonstrate DI and stubs/shims via the MS Fakes framework that's in VS2012/2013. 

There are two sets of projects in the solution, grouped by solution folder. "Exercise" contains the original application, and "Solution" contains my implementation of a solution.

The idea here is to give a practical demonstration of the benefits of unit testing -- the original exercise is not testable due to a hard dependency on on SQL CE, and the data that's in the database is randomly generated, so you can't even write a decent integration test.
I also stubbed out some unit tests for the class, so they have a starting point. There are, of course, many more things that can (and should) be tested!

There are two dependencies to break to enable testing: 
The first is the dependency on SQL CE, which can be accomplished with standard DI techniques and stubs/mocks.
The second is on DateTime.Now, which can be accomplished a few ways: You can wrap DateTime.Now up behind a class implementing an interface, inject a Func<DateTime> via the constructor, or use the MS Shims framework.