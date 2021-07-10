//user defined options (int) type
typedef enum {Rectangular, Triangular, Elliptical} Geometry;

//user defined structured type
typedef struct {
	float width;	//4 bytes
	float height; 	//4 bytes
	Geometry shape; //4 bytes
	char text[80];	//80 bytes
}Banner;


double BannerPrice(const Banner*);
int BannerPrint(Banner);

