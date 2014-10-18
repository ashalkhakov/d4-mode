D4 IDE
======

The goal is to create a newer IDE for D4.

To compile:

1. first, compile to dll (open up the solution and hit "Build all")

2. next, cd into this dir and perform the following command

$ mdtool setup pack MonoDevelop.D4Binding/MonoDevelop.D4Binding.addin.xml

There should be a file named MonoDevelop.D4Binding_V.mpack (where V
stands for version, e.g. 0.0.1), which you can install into MonoDevelop
via Tools -> Add-in Manager -> Install from file.
