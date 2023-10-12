
CREATE TABLE books
(
  book_id serial NOT NULL,
  title character varying(512) NOT NULL,
  pubyear smallint,
  numpages smallint,
  created timestamp without time zone DEFAULT now(),
  authors character varying(256) NOT NULL,
  CONSTRAINT books_pkey PRIMARY KEY (book_id),
  CONSTRAINT books_title_key UNIQUE (title)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE books OWNER TO postgres;