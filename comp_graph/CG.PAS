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
        width = 320;
        height = 200;

procedure putpixel(x,y:integer; c:byte);
begin
 mem[$A000:$140*y+x]:=c;
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

r.al := $13;

Intr($10,r);

{}
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
			PutPixel(mx + x,my + y,16 - (k mod 16));

			if cancel then exit;
		end;
	Readkey;

end.
