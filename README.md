# SPR Cricket Ticker #

Are you a cricket fan/fanatic/saddo? Are you fed up with having to swap back and forth between your browser and whatever you are working on just to keep track of the scores? 

I am. I was. 

So, having far too much time on my hands, I decided to create this little niche app - SPR Cricket Ticker - a simple, unobtrusive ticker that displays the most pertinent information about a selected cricket match whilst taking up very little screen real estate. 

But enough of the hard sell, if you have got this far you probably want to know how to use it...


## Instructions ##

Please download and install the latest `msi` from the Downloads page.

When started, SPR Cricket Ticker attempts to retrieve a list of active and upcoming international cricket matches from Yahoo.

Double-click an _upcoming_ game for more details.

Double-click an _active_ game to create a new ticker.

The ticker is always on top and can be dragged about the screen. Hover your mouse over the ticker for more details about the match. The ticker is updated every 30 seconds.


### Troubleshooting ###

A file called `Spr.CricketTicker.log` is used to record details about any unexpected error that might occur. This file can be found in the installation directory. Should the unthinkable happen, it would be really helpful if you could raise a [ticket](https://sourceforge.net/p/sprcrickettickr/tickets/) and attach this log file. Thanks.

## Development ##

SPR Cricket Ticker development environment, tools and techniques:

- VB.NET. 
- Visual Studio 2010.
- Windows 7 (64-Bit).
- Source control using _Git, GitFlow, GitHub_.
- TDD with _SpecFlow, NUnit, RhinoMocks_.
- Logging framework using _log4net_.
- Windows Installer XML (_WiX_) toolset.
- Nuget 'No-Commit' strategy, local server implementation.
- MSBuild script for Continuous Integration server (TeamCity, Jenkins).
- Model-View-Presenter (MVP) interface design.
- Manipulating Yahoo Query Language (YQL) results using LINQ.


## Feedback ##

Please submit feedback via the [Discussion Forum](https://sourceforge.net/p/sprcrickettickr/discussion/).  
Or raise an issue, feature request, etc. at the [Issue Tracker](https://sourceforge.net/p/sprcrickettickr/tickets/).


## Licenses ##
_SPR Cricket Ticker_ is distributed under the GNU General Public License, version 3.  
_Apache log4net_ is distributed under the Apache License, version 2.0.


-------------------------------------------
Copyright (c) 2012 Steve Roberts
