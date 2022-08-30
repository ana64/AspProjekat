# AspProjekat

An ASP.NET CORE API for movie ratings.

## Endpoints

### /api/Actor
| Method | Description |
| --- | --- |
| get | List all actors (search and pagination included) |
| post| Show file differences that haven't been staged |
| delete | Delete actor by id |

### /api/Cast
| Method | Description |
| --- | --- |
| post| Insert in AuthorMovie table (actorid,movieId,Role)|

### /api/Crew
| Method | Description |
| --- | --- |
| post| Add a movie's crew (director) and insert in pivot table |

### /api/Genre
| Method | Description |
| --- | --- |
| get | List all genres (search and pagination included) |
| post| Add a new genre |
| put  | Update genre|
| delete | Delete genre by id |

### /api/Movie
| Method | Description |
| --- | --- |
| get | List all movies (search and pagination included) |
| post| Add a new movie |

### /api/Rating
| Method | Description |
| --- | --- |
| post| Authorized user can rate a movie (he can't write a reviews yet)|

