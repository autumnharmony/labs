{computer graphic lab1}

uses WinDos,crt;

type
	Complex = Record
		x : Real;
		y : Real;
	end;

const
	iter = 20;
	max  = 1e+6;
	min  = 1e-6;
        width = 640;
        height = 200;


procedure putpixel6mode(x,y:integer; c:byte);
var b,n:byte; ev:boolean;
begin
     if (c = 1) then begin
     n := 1;
     n := n shl ( 7 - (x mod 8));
     end else begin
     n := 0;
     n := n shl ( 7 - (x mod 8));
     n := not n;
     end;


     if (y mod 2 = 0) then begin

     b := mem[$B800:($50*(y div 2)+ x div 8)];

     if (c=1) then
     b := b or n
     else b:= b and n;
     mem[$B800:($50*(y div 2)+ x div 8)]:=b;
     end

     else begin
      b:=mem[$B800:$2000+$50*((y-1)div 2)+ x div 8];

     if (c=1) then
     b := b or n
     else b:= b and n;

      mem[$B800:$2000+$50*((y-1)div 2)+ x div 8]:=b;
      end;
{     7 - (x mod 8)}






end;



var r:TRegisters;i:integer; ex,ey:real;

	z, t, d : Complex;
	p       :  Real;
	x, y, k : Integer;
	Cancel  : Boolean;
	gd, gm  : Integer;
	mx, my  : Integer;
        xa,xb,ya,yb:real;

begin
randomize;
r.ah := $00;
r.al := $6;
Intr($10,r);
{for mx:=0 to width do
 for my:=0 to height do
  if (mx*my mod 2 = 0) then putpixel6mode(mx,my,0) else  putpixel6mode(mx,my,1);}

xa := -1;
xb := 1;
ya := -1;
yb := 1;

ex := (xb - xa) / width;
ey := (yb - ya) / height;

mx := width div 2;
my := height div 2;

	Cancel := False;
        Randomize;

	Mx := WIDTH div 2;
	My := HEIGHT div 2;
	for y := -my to my do
		for x := -mx to mx do
		begin
			k := 0;
			z.x := X * ex;
			z.y := Y * ey;
			d := z;
			while (sqr(z.x)+sqr(z.y) < max) and
                              (sqr(d.x)+sqr(d.y) > min) and
                              (k < iter) do begin




			 t := z;
                         p:= 4*(t.x*t.x*t.x*t.x*t.x*t.x +
                             3 * t.x*t.x*t.x*t.x * t.y*t.y +
                             3 * t.x*t.x * t.y*t.y*t.y*t.y +
                             t.y*t.y*t.y*t.y*t.y*t.y);

                         z.x := (3/4)*t.x +
                              (t.x*t.x*t.x -
                              3 * t.x*t.y*t.y
                              )/p;

                         z.y := (3/4)*t.y - (3*t.x*t.x*t.y - t.y*t.y*t.y)/p;

                         d.x := abs(t.x - z.x);
			 d.y := abs(t.y - z.y);

                         Inc(k);
				if keypressed then
					Cancel := true;
			end;

                        putPixel6mode(mx + x,my + y,k mod 2);
			if cancel then exit;
		end;
	Readkey;

end.