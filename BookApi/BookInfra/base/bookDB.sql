PGDMP  	    -                }            BookDB    17.2    17.2 &               0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false                        0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false            !           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false            "           1262    32775    BookDB    DATABASE        CREATE DATABASE "BookDB" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Portuguese_Brazil.1252';
    DROP DATABASE "BookDB";
                     postgres    false            �            1259    32806    assunto    TABLE     j   CREATE TABLE public.assunto (
    codas integer NOT NULL,
    descricao character varying(20) NOT NULL
);
    DROP TABLE public.assunto;
       public         heap r       postgres    false            �            1259    32805    assunto_codas_seq    SEQUENCE     �   CREATE SEQUENCE public.assunto_codas_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public.assunto_codas_seq;
       public               postgres    false    223            #           0    0    assunto_codas_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE public.assunto_codas_seq OWNED BY public.assunto.codas;
          public               postgres    false    222            �            1259    32784    autor    TABLE     c   CREATE TABLE public.autor (
    codau integer NOT NULL,
    nome character varying(40) NOT NULL
);
    DROP TABLE public.autor;
       public         heap r       postgres    false            �            1259    32783    autor_codau_seq    SEQUENCE     �   CREATE SEQUENCE public.autor_codau_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 &   DROP SEQUENCE public.autor_codau_seq;
       public               postgres    false    220            $           0    0    autor_codau_seq    SEQUENCE OWNED BY     C   ALTER SEQUENCE public.autor_codau_seq OWNED BY public.autor.codau;
          public               postgres    false    219            �            1259    32777    livro    TABLE     �   CREATE TABLE public.livro (
    codl integer NOT NULL,
    titulo character varying(40) NOT NULL,
    editora character varying(40),
    edicao integer,
    anopublicacao character varying(4),
    valor numeric(10,2)
);
    DROP TABLE public.livro;
       public         heap r       postgres    false            �            1259    32812    livro_assunto    TABLE     k   CREATE TABLE public.livro_assunto (
    livro_codl integer NOT NULL,
    assunto_codas integer NOT NULL
);
 !   DROP TABLE public.livro_assunto;
       public         heap r       postgres    false            �            1259    32790    livro_autor    TABLE     g   CREATE TABLE public.livro_autor (
    livro_codl integer NOT NULL,
    autor_codau integer NOT NULL
);
    DROP TABLE public.livro_autor;
       public         heap r       postgres    false            �            1259    32776    livro_codl_seq    SEQUENCE     �   CREATE SEQUENCE public.livro_codl_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE public.livro_codl_seq;
       public               postgres    false    218            %           0    0    livro_codl_seq    SEQUENCE OWNED BY     A   ALTER SEQUENCE public.livro_codl_seq OWNED BY public.livro.codl;
          public               postgres    false    217            �            1259    40975    livro_detalhado    VIEW     S  CREATE VIEW public.livro_detalhado AS
SELECT
    NULL::integer AS codl,
    NULL::character varying(40) AS titulo,
    NULL::character varying(40) AS editora,
    NULL::integer AS edicao,
    NULL::character varying(4) AS anopublicacao,
    NULL::numeric(10,2) AS valor,
    NULL::text AS assuntosdescricao,
    NULL::text AS autoresnome;
 "   DROP VIEW public.livro_detalhado;
       public       v       postgres    false            �            1259    40980    vw_relatorio_autores    VIEW     �  CREATE VIEW public.vw_relatorio_autores AS
 SELECT au.codau AS autorid,
    au.nome AS autornome,
    string_agg(DISTINCT (ass.descricao)::text, ', '::text) AS assuntos,
    string_agg(DISTINCT (l.titulo)::text, ', '::text) AS livrosrelacionados,
    string_agg(DISTINCT (l.anopublicacao)::text, ', '::text) AS anospublicacao
   FROM ((((public.livro_autor la
     JOIN public.autor au ON ((la.autor_codau = au.codau)))
     JOIN public.livro l ON ((la.livro_codl = l.codl)))
     JOIN public.livro_assunto las ON ((las.livro_codl = l.codl)))
     JOIN public.assunto ass ON ((ass.codas = las.assunto_codas)))
  GROUP BY au.codau, au.nome
  ORDER BY au.nome;
 '   DROP VIEW public.vw_relatorio_autores;
       public       v       postgres    false    218    224    224    223    223    221    221    220    220    218    218            s           2604    32809    assunto codas    DEFAULT     n   ALTER TABLE ONLY public.assunto ALTER COLUMN codas SET DEFAULT nextval('public.assunto_codas_seq'::regclass);
 <   ALTER TABLE public.assunto ALTER COLUMN codas DROP DEFAULT;
       public               postgres    false    222    223    223            r           2604    32787    autor codau    DEFAULT     j   ALTER TABLE ONLY public.autor ALTER COLUMN codau SET DEFAULT nextval('public.autor_codau_seq'::regclass);
 :   ALTER TABLE public.autor ALTER COLUMN codau DROP DEFAULT;
       public               postgres    false    219    220    220            q           2604    32780 
   livro codl    DEFAULT     h   ALTER TABLE ONLY public.livro ALTER COLUMN codl SET DEFAULT nextval('public.livro_codl_seq'::regclass);
 9   ALTER TABLE public.livro ALTER COLUMN codl DROP DEFAULT;
       public               postgres    false    218    217    218                      0    32806    assunto 
   TABLE DATA           3   COPY public.assunto (codas, descricao) FROM stdin;
    public               postgres    false    223   �1                 0    32784    autor 
   TABLE DATA           ,   COPY public.autor (codau, nome) FROM stdin;
    public               postgres    false    220   2                 0    32777    livro 
   TABLE DATA           T   COPY public.livro (codl, titulo, editora, edicao, anopublicacao, valor) FROM stdin;
    public               postgres    false    218   �2                 0    32812    livro_assunto 
   TABLE DATA           B   COPY public.livro_assunto (livro_codl, assunto_codas) FROM stdin;
    public               postgres    false    224   �3                 0    32790    livro_autor 
   TABLE DATA           >   COPY public.livro_autor (livro_codl, autor_codau) FROM stdin;
    public               postgres    false    221   �3       &           0    0    assunto_codas_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public.assunto_codas_seq', 9, true);
          public               postgres    false    222            '           0    0    autor_codau_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public.autor_codau_seq', 7, true);
          public               postgres    false    219            (           0    0    livro_codl_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public.livro_codl_seq', 22, true);
          public               postgres    false    217            {           2606    32811    assunto assunto_pkey 
   CONSTRAINT     U   ALTER TABLE ONLY public.assunto
    ADD CONSTRAINT assunto_pkey PRIMARY KEY (codas);
 >   ALTER TABLE ONLY public.assunto DROP CONSTRAINT assunto_pkey;
       public                 postgres    false    223            w           2606    32789    autor autor_pkey 
   CONSTRAINT     Q   ALTER TABLE ONLY public.autor
    ADD CONSTRAINT autor_pkey PRIMARY KEY (codau);
 :   ALTER TABLE ONLY public.autor DROP CONSTRAINT autor_pkey;
       public                 postgres    false    220            }           2606    32816     livro_assunto livro_assunto_pkey 
   CONSTRAINT     u   ALTER TABLE ONLY public.livro_assunto
    ADD CONSTRAINT livro_assunto_pkey PRIMARY KEY (livro_codl, assunto_codas);
 J   ALTER TABLE ONLY public.livro_assunto DROP CONSTRAINT livro_assunto_pkey;
       public                 postgres    false    224    224            y           2606    32794    livro_autor livro_autor_pkey 
   CONSTRAINT     o   ALTER TABLE ONLY public.livro_autor
    ADD CONSTRAINT livro_autor_pkey PRIMARY KEY (livro_codl, autor_codau);
 F   ALTER TABLE ONLY public.livro_autor DROP CONSTRAINT livro_autor_pkey;
       public                 postgres    false    221    221            u           2606    32782    livro livro_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY public.livro
    ADD CONSTRAINT livro_pkey PRIMARY KEY (codl);
 :   ALTER TABLE ONLY public.livro DROP CONSTRAINT livro_pkey;
       public                 postgres    false    218                       2618    40978    livro_detalhado _RETURN    RULE     u  CREATE OR REPLACE VIEW public.livro_detalhado AS
 SELECT l.codl,
    l.titulo,
    l.editora,
    l.edicao,
    l.anopublicacao,
    l.valor,
    string_agg(DISTINCT (asu.descricao)::text, ', '::text) AS assuntosdescricao,
    string_agg(DISTINCT (aut.nome)::text, ', '::text) AS autoresnome
   FROM ((((public.livro l
     LEFT JOIN public.livro_assunto a ON ((a.livro_codl = l.codl)))
     LEFT JOIN public.livro_autor au ON ((au.livro_codl = l.codl)))
     LEFT JOIN public.assunto asu ON ((asu.codas = a.assunto_codas)))
     LEFT JOIN public.autor aut ON ((aut.codau = au.autor_codau)))
  GROUP BY l.codl
  ORDER BY l.codl;
 ^  CREATE OR REPLACE VIEW public.livro_detalhado AS
SELECT
    NULL::integer AS codl,
    NULL::character varying(40) AS titulo,
    NULL::character varying(40) AS editora,
    NULL::integer AS edicao,
    NULL::character varying(4) AS anopublicacao,
    NULL::numeric(10,2) AS valor,
    NULL::text AS assuntosdescricao,
    NULL::text AS autoresnome;
       public               postgres    false    223    223    221    221    220    220    218    4725    218    218    218    218    218    224    224    225            �           2606    32822 .   livro_assunto livro_assunto_assunto_codas_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.livro_assunto
    ADD CONSTRAINT livro_assunto_assunto_codas_fkey FOREIGN KEY (assunto_codas) REFERENCES public.assunto(codas) ON DELETE CASCADE;
 X   ALTER TABLE ONLY public.livro_assunto DROP CONSTRAINT livro_assunto_assunto_codas_fkey;
       public               postgres    false    224    4731    223            �           2606    32817 +   livro_assunto livro_assunto_livro_codl_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.livro_assunto
    ADD CONSTRAINT livro_assunto_livro_codl_fkey FOREIGN KEY (livro_codl) REFERENCES public.livro(codl) ON DELETE CASCADE;
 U   ALTER TABLE ONLY public.livro_assunto DROP CONSTRAINT livro_assunto_livro_codl_fkey;
       public               postgres    false    4725    224    218            ~           2606    32800 (   livro_autor livro_autor_autor_codau_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.livro_autor
    ADD CONSTRAINT livro_autor_autor_codau_fkey FOREIGN KEY (autor_codau) REFERENCES public.autor(codau) ON DELETE CASCADE;
 R   ALTER TABLE ONLY public.livro_autor DROP CONSTRAINT livro_autor_autor_codau_fkey;
       public               postgres    false    220    221    4727                       2606    32795 '   livro_autor livro_autor_livro_codl_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.livro_autor
    ADD CONSTRAINT livro_autor_livro_codl_fkey FOREIGN KEY (livro_codl) REFERENCES public.livro(codl) ON DELETE CASCADE;
 Q   ALTER TABLE ONLY public.livro_autor DROP CONSTRAINT livro_autor_livro_codl_fkey;
       public               postgres    false    218    221    4725               3   x�3�I-*�/�2�tK�+I,�L����M�KN��t)J�M����� �"         k   x�3�t�<�9%�H�%��$?��ʲ��L.N���<����Ĝ������������<.SN���2�����L.3N�ĢJ���Ԝ��J.sN���\������"�=... U�"�         �   x���Mn� F���	,�m�P��@6��n�[c�Ro�(�X��t]dFF�����^�%^�.���r��a:���8�*�/�Ӎ֪G�9�i���|Y�=�8�=����#"����8�aE�����4c#��J��&����1�1�r��?�]�F8���ﹰ/�{�iS��$�tZ���;~�|���Rޢ���6��(|�L�N_Z�}B��F�M���*�_�x��
�Z>��ۚN.�c���<��R         8   x�%��� ����(�(��B�up��H����(4b�:�K�|/���q��i�l[=	�         9   x�%��  B�sƈ�wq�9�xy�Θ`�+
ܞ�L���BE]C�(����
'     