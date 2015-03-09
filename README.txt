This project provides a Common Language Interface (CLI) Library for OSGeo's 
Proj.4 package. 

The built dll has been tested with the Unity GameEngine and .NET. The .NET 
wrapper class was originally built by Eric G. Miller and is being redistributed 
under the terms of that license.

Installation
------------
Install Proj.4 and make sure proj.dll is in your path. For datum shifting, 
Proj.4 needs to be able to find your proj/nad directory (and the associated 
data). By default it looks in C:\proj\nad or wherever your PROJ_LIB 
environmental variable is pointing. 

See: http://trac.osgeo.org/proj/wiki/FAQ
for more information.


.NET Integration
----------------
Add proj_api.dll to your References. Refer to the "proj_api Test 3" for example
usage.

Unity3D Integration
-------------------
Add proj_api.dll to your Assets folder. For standalone deployments the obvious 
caveats are endusers may not have proj.dll or the proj/nad directory available.