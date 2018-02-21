Paper Round
-----------

Please implement code to deliver the user stories below as described by their acceptance criteria (ACs).

You should aim to deliver a working solution that is straightforward, maintainable, bug free, production quality and employing best software development
practices. You may find ambiguities in the requirements that in the 'real world' you would clarify with a business analyst. For the purpose of this 
test, please highlight any assumptions that you have had to make in developing your solution.

You should feel free to use any other tools you are more comfortable with.


User Stories
============


Story 1
-------

A town planner is responsible for keeping track of the layout of a street and numbering houses. The layout is stored in a street specification file. 
An example is given in street1.txt

The street specification file can be interpreted as follows:
	- The street specification file lists all the house numbers in the street from west to east.
	- House numbering starts from 1
	- All the houses on the left-hand (north) side of the street are odd numbered
	- All the houses on the right-hand (south) side of the street are even numbered
	- For example, a street specification file containing "1 3 2" can be interpreted as there being, from west to east:
		- house #1 on the left-hand (north) side of the street, 
		- followed by house #3, also on the left-hand (north) side of the street, 
		- followed by house #2 on the right-hand (south) side of the street.
		- (Note: in the real world houses on a street are frequently directly opposite each other. For this purposes of this exercise, 
		  this is assumed never to be the case!)
	- On each side of the street no number can be skipped and no number can be used more than once

As a town planner, given a street specification file, I want to display a report showing:

AC1. that the file is valid.
AC2. how many houses there are in a given street
AC3. how many houses are on the left hand (north) side of the street
AC4. how many houses are on the right hand (south) side of the street


Story 2
-------

A paper boy or girl delivers newspapers to all the houses in a given street. They are experimenting with two approaches to delivering papers:
(1) In one approach they first travel from west to east delivering to the houses on the left hand (north) side of the street. They then travel east to 
    west delivering to houses on the south side of the street.
(2) In the second approach they deliver to each house in turn from west to east, regardless of which side of the road they are on.

As a newspaper boy or girl given a street, I want to know for both approaches (1) and (2):

AC5. the list of house numbers in the order that I will be delivering to, so that I can sort by satchel in advance
AC6. how many times I will have to cross the road from one side to the other to make my deliveries
