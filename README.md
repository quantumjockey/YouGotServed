YouGotServed
=============

A library of wrapper functions that prevent you from having to pull your hair out when manipulating files on servers/remote machines through FTP.

Summary
-------

This library is based almost entirely around the notion that a developer can focus on making awesome software when another (hopefully not boring) developer worries about the details for them. It only has a few methods for now, but will grow with the needs of my personal and university projects. It's also guaranteed to grow if Microsoft doesn't screw up their strategies for emerging versions of Windows - but that's another conversation altogether.

Notes
-----

This library takes much of its component material (a.k.a. "The Details") from an understanding of material published in [How to: Upload Files with FTP](http://msdn.microsoft.com/en-us/library/ms229715(v=vs.100).aspx) on MSDN. More functionality to come. Any future implementations inspired by or closely adhering to material from MSDN will be referenced in this section, as well as explanation of any significant technical concerns that may arise during testing.

This solution, including unit tests and architectural models, was created, debugged, and deployed using [Visual Studio 2012 Ultimate with MSDN](http://en.wikipedia.org/wiki/Microsoft_Visual_Studio#Visual_Studio_2012) (link contains addtional references). The solution may not open properly if you try using an earlier or less feature-saturated version of Visual Studio. If a later version is used, be sure to check the cloned solution against original source code to ensure that compatiblity changes haven't significantly altered existing functionality.

Instructions
------------

To get your machine ready for development with this repository:

1. Clone the repository to your machine.
2. Navigate to the directory you cloned your repository to.
3. Locate the Visual Studio 2012 solution file.
3. Open the solution in Visual Studio (2012 or later)

Viola! You're good to go!
