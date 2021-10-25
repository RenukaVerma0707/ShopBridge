Æ
sC:\Users\Ritesh Nirgude\source\repos\ShopBridge.Products\ShopBridge.Products.Infrastructure\Interfaces\IProducts.cs
	namespace 	

ShopBridge
 
. 
Infrastrusture #
.# $

Interfaces$ .
{ 
public 

	interface 
	IProducts 
{		 
Task

 
<

 
List

 
<

 
Products

 
>

 
>

 
GetProducts

 (
(

( )
)

) *
;

* +
Task 
< 
Products 
> 

AddProduct !
(! "
ProductRequest" 0
products1 9
)9 :
;: ;
Task 
< 
string 
> 
UpdateProduct "
(" #
Products# +
products, 4
)4 5
;5 6
Task 
< 
string 
> 
Delete 
( 
Guid  
id! #
)# $
;$ %
} 
} à
C:\Users\Ritesh Nirgude\source\repos\ShopBridge.Products\ShopBridge.Products.Infrastructure\Migrations\20211024111054_Products.cs
	namespace 	

ShopBridge
 
. 
Infrastructure #
.# $

Migrations$ .
{ 
public 

partial 
class 
Products !
:" #
	Migration$ -
{ 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{		 	
migrationBuilder

 
.

 
CreateTable

 (
(

( )
name 
: 
$str  
,  !
columns 
: 
table 
=> !
new" %
{ 
	ProductId 
= 
table  %
.% &
Column& ,
<, -
Guid- 1
>1 2
(2 3
type3 7
:7 8
$str9 K
,K L
nullableM U
:U V
falseW \
)\ ]
,] ^
ProductName 
=  !
table" '
.' (
Column( .
<. /
string/ 5
>5 6
(6 7
type7 ;
:; <
$str= L
,L M
nullableN V
:V W
trueX \
)\ ]
,] ^
ProductDescription &
=' (
table) .
.. /
Column/ 5
<5 6
string6 <
>< =
(= >
type> B
:B C
$strD S
,S T
nullableU ]
:] ^
true_ c
)c d
,d e
Price 
= 
table !
.! "
Column" (
<( )
decimal) 0
>0 1
(1 2
type2 6
:6 7
$str8 G
,G H
nullableI Q
:Q R
falseS X
)X Y
,Y Z
Quantity 
= 
table $
.$ %
Column% +
<+ ,
int, /
>/ 0
(0 1
type1 5
:5 6
$str7 <
,< =
nullable> F
:F G
falseH M
)M N
} 
, 
constraints 
: 
table "
=># %
{ 
table 
. 

PrimaryKey $
($ %
$str% 2
,2 3
x4 5
=>6 8
x9 :
.: ;
	ProductId; D
)D E
;E F
} 
) 
; 
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
migrationBuilder 
. 
	DropTable &
(& '
name 
: 
$str  
)  !
;! "
} 	
} 
}   ä
tC:\Users\Ritesh Nirgude\source\repos\ShopBridge.Products\ShopBridge.Products.Infrastructure\Models\ProductRequest.cs
	namespace 	

ShopBridge
 
. 
Infrastrusture #
.# $
Models$ *
{ 
public 

class 
ProductRequest 
{ 
public 
string 
ProductName !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
string 
ProductDescription (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public

 
decimal

 
Price

 
{

 
get

 "
;

" #
set

$ '
;

' (
}

) *
public 
int 
Quantity 
{ 
get !
;! "
set# &
;& '
}( )
} 
} ƒ

nC:\Users\Ritesh Nirgude\source\repos\ShopBridge.Products\ShopBridge.Products.Infrastructure\Models\Products.cs
	namespace 	

ShopBridge
 
. 
Infrastrusture #
.# $
Models$ *
{ 
[ 
Table 

(
 
$str 
) 
] 
public 

class 
Products 
{		 
[

 	
Key

	 
]

 
public 
Guid 
	ProductId 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
ProductName !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
string 
ProductDescription (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
decimal 
Price 
{ 
get "
;" #
set$ '
;' (
}) *
public 
int 
Quantity 
{ 
get !
;! "
set# &
;& '
}( )
} 
} °
oC:\Users\Ritesh Nirgude\source\repos\ShopBridge.Products\ShopBridge.Products.Infrastructure\ProductDbContext.cs
	namespace 	

ShopBridge
 
. 
Infrastrusture #
{ 
public 

class 
ProductDbContext !
:" #
	DbContext$ -
{ 
public 
ProductDbContext 
(  
DbContextOptions  0
options1 8
)8 9
:: ;
base< @
(@ A
optionsA H
)H I
{J K
}L M
public		 
DbSet		 
<		 
Products		 
>		 
Products		 '
{		( )
get		* -
;		- .
set		/ 2
;		2 3
}		4 5
}

 
} Œ(
wC:\Users\Ritesh Nirgude\source\repos\ShopBridge.Products\ShopBridge.Products.Infrastructure\Services\ProductsService.cs
	namespace

 	

ShopBridge


 
.

 
Infrastrusture

 #
.

# $
Services

$ ,
{ 
public 

class 
ProductsService  
:! "
	IProducts# ,
{ 
private 
readonly 
ProductDbContext )
_productDbContext* ;
;; <
private 
readonly 
ILogger  
<  !
ProductsService! 0
>0 1
_logger2 9
;9 :
public 
ProductsService 
( 
ProductDbContext /
productDbContext0 @
,@ A
ILoggerB I
<I J
ProductsServiceJ Y
>Y Z
logger[ a
)a b
{ 	
_productDbContext 
= 
productDbContext  0
;0 1
_logger 
= 
logger 
; 
} 	
public 
async 
Task 
< 
Products "
>" #

AddProduct$ .
(. /
ProductRequest/ =
products> F
)F G
{ 	
Products 
product 
= 
Utility &
.& '
Utility' .
.. /
ModelToEntity/ <
(< =
products= E
)E F
;F G
await 
_productDbContext #
.# $
AddAsync$ ,
(, -
product- 4
)4 5
;5 6
await 
_productDbContext #
.# $
SaveChangesAsync$ 4
(4 5
)5 6
;6 7
return 
product 
; 
} 	
public   
async   
Task   
<   
string    
>    !
Delete  " (
(  ( )
Guid  ) -
id  . 0
)  0 1
{!! 	
var"" 
products"" 
="" 
await""  
_productDbContext""! 2
.""2 3
Products""3 ;
.""; <
Where""< A
(""A B
x""B C
=>""D F
x""G H
.""H I
	ProductId""I R
==""S U
id""V X
)""X Y
.""Y Z
AsNoTracking""Z f
(""f g
)""g h
.""h i
FirstOrDefaultAsync""i |
(""| }
)""} ~
;""~ 
if## 
(## 
products## 
!=## 
null##  
)##  !
{$$ 
_productDbContext%% !
.%%! "
Products%%" *
.%%* +
Remove%%+ 1
(%%1 2
products%%2 :
)%%: ;
;%%; <
await&& 
_productDbContext&& '
.&&' (
SaveChangesAsync&&( 8
(&&8 9
)&&9 :
;&&: ;
return'' 
$str'' 5
;''5 6
})) 
return** 
null** 
;** 
}++ 	
public-- 
async-- 
Task-- 
<-- 
List-- 
<-- 
Products-- '
>--' (
>--( )
GetProducts--* 5
(--5 6
)--6 7
{.. 	
var// 
products// 
=// 
await//  
_productDbContext//! 2
.//2 3
Products//3 ;
.//; <
AsNoTracking//< H
(//H I
)//I J
.//J K
ToListAsync//K V
(//V W
)//W X
;//X Y
return00 
products00 
;00 
}11 	
public33 
async33 
Task33 
<33 
string33  
>33  !
UpdateProduct33" /
(33/ 0
Products330 8
product339 @
)33@ A
{44 	
var55 
products55 
=55 
await55  
_productDbContext55! 2
.552 3
Products553 ;
.55; <
Where55< A
(55A B
x55B C
=>55D F
x55G H
.55H I
	ProductId55I R
==55S U
product55V ]
.55] ^
	ProductId55^ g
)55g h
.55h i
AsNoTracking55i u
(55u v
)55v w
.55w x 
FirstOrDefaultAsync	55x ‹
(
55‹ Œ
)
55Œ 
;
55 Ž
if88 
(88 
products88 
!=88 
null88  
)88  !
{99 
var:: 
result:: 
=:: 
_productDbContext:: .
.::. /
Update::/ 5
(::5 6
product::6 =
)::= >
;::> ?
await;; 
_productDbContext;; '
.;;' (
SaveChangesAsync;;( 8
(;;8 9
);;9 :
;;;: ;
return<< 
$str<< 5
;<<5 6
}== 
return>> 
null>> 
;>> 
}@@ 	
}BB 
}CC ½	
nC:\Users\Ritesh Nirgude\source\repos\ShopBridge.Products\ShopBridge.Products.Infrastructure\Utility\Utility.cs
	namespace 	

ShopBridge
 
. 
Infrastrusture #
.# $
Utility$ +
{ 
public 

class 
Utility 
{ 
public 
static 
Products 
ModelToEntity ,
(, -
ProductRequest- ;
model< A
)A B
{ 	
Products		 
product		 
=		 
new		 "
Products		# +
(		+ ,
)		, -
{

 
ProductName 
= 
model #
.# $
ProductName$ /
,/ 0
ProductDescription "
=# $
model% *
.* +
ProductDescription+ =
,= >
Price 
= 
model 
. 
Price #
,# $
Quantity 
= 
model  
.  !
Quantity! )
} 
; 
return 
product 
; 
} 	
} 
} 