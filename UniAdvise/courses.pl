course(mat151).
course(bsc152).
course(gse153).
course(gse154).
course(com155).
course(eng156).

course(mat161).
course(bsc162).
course(gse163).
course(bsc164).
course(gse165).
course(eng166).

course(mat251).
course(bsc252).
course(ese253).
course(ece254).
course(com255).
course(eng256).

course(mat261).
course(ese262).
course(ese263).
course(ece264).
course(com265).
course(soc266).

course(mat351).
course(cse352).
course(ece353).
course(ece354).
course(ece355).
course(ece356).

course(mat361).
course(cse362).
course(ece363).
course(ece364).
course(ece365).
course(ece366).

course(ece451).
course(ece452).
course(ece453x).
course(ece454).
course(ece455).
course(cse456).

course(ece461).
course(ece462).
course(ece463x).
course(ece464).
course(ece465).
course(ece466).

course(ece551).
course(ece552).
course(ece553x).
course(ece554).

course(ece561).
course(gse562).
course(ece563x).
course(ece564).

prereq(mat161,mat151).
prereq(bsc162,bsc152).
prereq(gse163,gse153).
prereq(eng166,eng156).

prereq(mat251,mat161).
prereq(bsc252,bsc162).
prereq(ese253,bsc162).
prereq(com255,com155).
prereq(eng256,eng166).

prereq(mat261,mat161).
prereq(ese262,bsc252).
prereq(ese263,ese254).
prereq(ece264,ece254).
prereq(com265,com255).
prereq(soc266,eng256).

prereq(mat351,mat261).
prereq(cse352,ece264).
prereq(cse352,com265).
prereq(ece353,ese263).
prereq(ece354,mat251).
prereq(ece355,mat251).
prereq(ece356,ese263).

prereq(mat361,mat351).
prereq(cse362,cse352).
prereq(cse362,com265).
prereq(ece363,ece353).
prereq(ece364,ece354).
prereq(ece365,ese263).
prereq(ece365,mat351).
prereq(ece366,ece355).

prereq(ece451,ece363).
prereq(ece452,ece365).
prereq(ece454,ece364).
prereq(ece455,ece365).
prereq(cse456,cse362).

prereq(ece461,ece541).
prereq(ece462,ece452).
prereq(ece462,mat361).
prereq(ece464,ece454).
prereq(ece465,ece462).
prereq(ese466,ece365).

prereq(ese551,ece455).
prereq(ece552,ece464).

prereq(ece561,ece264).
prereq(ece561,ece363).
prereq(ece564,ece554).
