﻿using EK7TKN_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EK7TKN_HFT_2021221.Data
{
    public class xDbContext : DbContext
    {
        //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True

        public virtual DbSet<RunInformation> Runs { get; set; }
        public virtual DbSet<PasswordSecurity> Passwords { get; set; }
        public virtual DbSet<UserInformation> Users { get; set; }

        public xDbContext(DbContextOptions<xDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }
        public xDbContext() 
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                   

                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var listau = new List<UserInformation>()
            {

new UserInformation() { First_Name = "	Delly	", Last_Name="	Caldwall	",Email="	dcaldwall0@ifeng.com	",Age=  39  ,Height=    169 ,Weight=    80  ,UserID=    1   },
new UserInformation() { First_Name = "	Aurora	", Last_Name="	Quartermaine	",Email="	aquartermaine1@fema.gov	",Age=  22  ,Height=    140 ,Weight=    99  ,UserID=    2   },
new UserInformation() { First_Name = "	Elwira	", Last_Name="	Rembaud	",Email="	erembaud2@dyndns.org	",Age=  63  ,Height=    195 ,Weight=    73  ,UserID=    3   },
new UserInformation() { First_Name = "	Marika	", Last_Name="	Divisek	",Email="	mdivisek3@spotify.com	",Age=  63  ,Height=    147 ,Weight=    64  ,UserID=    4   },
new UserInformation() { First_Name = "	Dalila	", Last_Name="	Ausiello	",Email="	dausiello4@gravatar.com	",Age=  35  ,Height=    200 ,Weight=    97  ,UserID=    5   },
new UserInformation() { First_Name = "	Farrel	", Last_Name="	Orneblow	",Email="	forneblow5@dmoz.org	",Age=  48  ,Height=    171 ,Weight=    110 ,UserID=    6   },
new UserInformation() { First_Name = "	Kerwin	", Last_Name="	Challicombe	",Email="	kchallicombe6@51.la	",Age=  38  ,Height=    185 ,Weight=    106 ,UserID=    7   },
new UserInformation() { First_Name = "	Cori	", Last_Name="	Silk	",Email="	csilk7@yelp.com	",Age=  32  ,Height=    179 ,Weight=    91  ,UserID=    8   },
new UserInformation() { First_Name = "	Vallie	", Last_Name="	Simukov	",Email="	vsimukov8@latimes.com	",Age=  30  ,Height=    156 ,Weight=    56  ,UserID=    9   },
new UserInformation() { First_Name = "	Burt	", Last_Name="	Wendover	",Email="	bwendover9@fotki.com	",Age=  69  ,Height=    124 ,Weight=    73  ,UserID=    10  },
new UserInformation() { First_Name = "	Chevalier	", Last_Name="	Edwardson	",Email="	cedwardsona@ft.com	",Age=  50  ,Height=    128 ,Weight=    63  ,UserID=    11  },
new UserInformation() { First_Name = "	Vachel	", Last_Name="	Mityushin	",Email="	vmityushinb@jalbum.net	",Age=  25  ,Height=    121 ,Weight=    105 ,UserID=    12  },
new UserInformation() { First_Name = "	Gerick	", Last_Name="	Ciottoi	",Email="	gciottoic@reference.com	",Age=  63  ,Height=    171 ,Weight=    83  ,UserID=    13  },
new UserInformation() { First_Name = "	Skippy	", Last_Name="	Funcheon	",Email="	sfuncheond@furl.net	",Age=  37  ,Height=    138 ,Weight=    94  ,UserID=    14  },
new UserInformation() { First_Name = "	Viviana	", Last_Name="	Rummings	",Email="	vrummingse@arstechnica.com	",Age=  44  ,Height=    192 ,Weight=    65  ,UserID=    15  },
new UserInformation() { First_Name = "	Jermaine	", Last_Name="	Inwood	",Email="	jinwoodf@columbia.edu	",Age=  38  ,Height=    177 ,Weight=    67  ,UserID=    16  },
new UserInformation() { First_Name = "	Teri	", Last_Name="	Silley	",Email="	tsilleyg@networkadvertising.org	",Age=  60  ,Height=    136 ,Weight=    50  ,UserID=    17  },
new UserInformation() { First_Name = "	Emmeline	", Last_Name="	Foxten	",Email="	efoxtenh@redcross.org	",Age=  23  ,Height=    193 ,Weight=    57  ,UserID=    18  },
new UserInformation() { First_Name = "	Corina	", Last_Name="	Alberts	",Email="	calbertsi@wikia.com	",Age=  36  ,Height=    139 ,Weight=    85  ,UserID=    19  },
new UserInformation() { First_Name = "	Ximenez	", Last_Name="	Joss	",Email="	xjossj@blinklist.com	",Age=  44  ,Height=    182 ,Weight=    92  ,UserID=    20  },
new UserInformation() { First_Name = "	Leighton	", Last_Name="	Musselwhite	",Email="	lmusselwhitek@sogou.com	",Age=  63  ,Height=    168 ,Weight=    88  ,UserID=    21  },
new UserInformation() { First_Name = "	Ammamaria	", Last_Name="	Cowey	",Email="	acoweyl@loc.gov	",Age=  60  ,Height=    192 ,Weight=    64  ,UserID=    22  },
new UserInformation() { First_Name = "	Malinda	", Last_Name="	Celle	",Email="	mcellem@odnoklassniki.ru	",Age=  54  ,Height=    159 ,Weight=    78  ,UserID=    23  },
new UserInformation() { First_Name = "	Mirabel	", Last_Name="	Curnokk	",Email="	mcurnokkn@chicagotribune.com	",Age=  47  ,Height=    131 ,Weight=    105 ,UserID=    24  },
new UserInformation() { First_Name = "	Netti	", Last_Name="	Pettie	",Email="	npettieo@dedecms.com	",Age=  34  ,Height=    181 ,Weight=    57  ,UserID=    25  },
new UserInformation() { First_Name = "	Jose	", Last_Name="	Cronk	",Email="	jcronkp@noaa.gov	",Age=  26  ,Height=    162 ,Weight=    93  ,UserID=    26  },
new UserInformation() { First_Name = "	Dasha	", Last_Name="	Bryers	",Email="	dbryersq@bizjournals.com	",Age=  50  ,Height=    185 ,Weight=    101 ,UserID=    27  },
new UserInformation() { First_Name = "	Ruprecht	", Last_Name="	Skarr	",Email="	rskarrr@artisteer.com	",Age=  53  ,Height=    139 ,Weight=    51  ,UserID=    28  },
new UserInformation() { First_Name = "	Willette	", Last_Name="	Rosenberg	",Email="	wrosenbergs@sitemeter.com	",Age=  22  ,Height=    166 ,Weight=    73  ,UserID=    29  },
new UserInformation() { First_Name = "	Rosemaria	", Last_Name="	Kennaird	",Email="	rkennairdt@omniture.com	",Age=  34  ,Height=    198 ,Weight=    64  ,UserID=    30  },
new UserInformation() { First_Name = "	Karolina	", Last_Name="	Glowacki	",Email="	kglowackiu@usatoday.com	",Age=  55  ,Height=    158 ,Weight=    77  ,UserID=    31  },
new UserInformation() { First_Name = "	Jere	", Last_Name="	Kellick	",Email="	jkellickv@rediff.com	",Age=  57  ,Height=    150 ,Weight=    103 ,UserID=    32  },
new UserInformation() { First_Name = "	Arnuad	", Last_Name="	Ashborn	",Email="	aashbornw@cdbaby.com	",Age=  46  ,Height=    177 ,Weight=    74  ,UserID=    33  },
new UserInformation() { First_Name = "	Ambrosius	", Last_Name="	Viggars	",Email="	aviggarsx@hp.com	",Age=  29  ,Height=    183 ,Weight=    84  ,UserID=    34  },
new UserInformation() { First_Name = "	Kit	", Last_Name="	Bryceson	",Email="	kbrycesony@unicef.org	",Age=  66  ,Height=    190 ,Weight=    80  ,UserID=    35  },
new UserInformation() { First_Name = "	Hagen	", Last_Name="	Batten	",Email="	hbattenz@comsenz.com	",Age=  45  ,Height=    164 ,Weight=    80  ,UserID=    36  },
new UserInformation() { First_Name = "	Stillmann	", Last_Name="	Tures	",Email="	stures10@house.gov	",Age=  65  ,Height=    152 ,Weight=    55  ,UserID=    37  },
new UserInformation() { First_Name = "	Morgana	", Last_Name="	Goodred	",Email="	mgoodred11@marketwatch.com	",Age=  50  ,Height=    128 ,Weight=    50  ,UserID=    38  },
new UserInformation() { First_Name = "	Cathleen	", Last_Name="	Tuley	",Email="	ctuley12@list-manage.com	",Age=  34  ,Height=    147 ,Weight=    63  ,UserID=    39  },
new UserInformation() { First_Name = "	Aarika	", Last_Name="	Ream	",Email="	aream13@wordpress.com	",Age=  19  ,Height=    145 ,Weight=    69  ,UserID=    40  },
new UserInformation() { First_Name = "	Cameron	", Last_Name="	Althorpe	",Email="	calthorpe14@freewebs.com	",Age=  26  ,Height=    197 ,Weight=    51  ,UserID=    41  },
new UserInformation() { First_Name = "	Kinsley	", Last_Name="	Foord	",Email="	kfoord15@amazonaws.com	",Age=  36  ,Height=    191 ,Weight=    55  ,UserID=    42  },
new UserInformation() { First_Name = "	Joscelin	", Last_Name="	Sute	",Email="	jsute16@list-manage.com	",Age=  70  ,Height=    164 ,Weight=    52  ,UserID=    43  },
new UserInformation() { First_Name = "	Fran	", Last_Name="	Doctor	",Email="	fdoctor17@4shared.com	",Age=  41  ,Height=    160 ,Weight=    87  ,UserID=    44  },
new UserInformation() { First_Name = "	Homere	", Last_Name="	Loos	",Email="	hloos18@drupal.org	",Age=  29  ,Height=    175 ,Weight=    57  ,UserID=    45  },
new UserInformation() { First_Name = "	Homer	", Last_Name="	Mordecai	",Email="	hmordecai19@arstechnica.com	",Age=  31  ,Height=    126 ,Weight=    67  ,UserID=    46  },
new UserInformation() { First_Name = "	Mignon	", Last_Name="	Belliss	",Email="	mbelliss1a@timesonline.co.uk	",Age=  70  ,Height=    143 ,Weight=    91  ,UserID=    47  },
new UserInformation() { First_Name = "	Irina	", Last_Name="	Abrahart	",Email="	iabrahart1b@twitter.com	",Age=  47  ,Height=    132 ,Weight=    50  ,UserID=    48  },
new UserInformation() { First_Name = "	Hubie	", Last_Name="	Rookesby	",Email="	hrookesby1c@businessinsider.com	",Age=  40  ,Height=    192 ,Weight=    108 ,UserID=    49  },
new UserInformation() { First_Name = "	Mattie	", Last_Name="	Peskett	",Email="	mpeskett1d@nps.gov	",Age=  57  ,Height=    176 ,Weight=    102 ,UserID=    50  },
new UserInformation() { First_Name = "	Elie	", Last_Name="	Tong	",Email="	etong1e@blogs.com	",Age=  62  ,Height=    190 ,Weight=    62  ,UserID=    51  },
new UserInformation() { First_Name = "	Ninon	", Last_Name="	Stadden	",Email="	nstadden1f@photobucket.com	",Age=  70  ,Height=    165 ,Weight=    69  ,UserID=    52  },
new UserInformation() { First_Name = "	Idelle	", Last_Name="	Bursell	",Email="	ibursell1g@scribd.com	",Age=  18  ,Height=    140 ,Weight=    73  ,UserID=    53  },
new UserInformation() { First_Name = "	Chicky	", Last_Name="	O'Shesnan	",Email="	coshesnan1h@cdbaby.com	",Age=  56  ,Height=    140 ,Weight=    75  ,UserID=    54  },
new UserInformation() { First_Name = "	Nesta	", Last_Name="	Van Salzberger	",Email="	nvansalzberger1i@newsvine.com	",Age=  69  ,Height=    164 ,Weight=    105 ,UserID=    55  },
new UserInformation() { First_Name = "	Cybil	", Last_Name="	Kornilov	",Email="	ckornilov1j@facebook.com	",Age=  68  ,Height=    130 ,Weight=    108 ,UserID=    56  },
new UserInformation() { First_Name = "	Elberta	", Last_Name="	Brunnen	",Email="	ebrunnen1k@etsy.com	",Age=  26  ,Height=    196 ,Weight=    104 ,UserID=    57  },
new UserInformation() { First_Name = "	Alix	", Last_Name="	Sor	",Email="	asor1l@so-net.ne.jp	",Age=  49  ,Height=    143 ,Weight=    89  ,UserID=    58  },
new UserInformation() { First_Name = "	Patsy	", Last_Name="	Lambricht	",Email="	plambricht1m@mail.ru	",Age=  21  ,Height=    174 ,Weight=    103 ,UserID=    59  },
new UserInformation() { First_Name = "	Ewell	", Last_Name="	Tuxsell	",Email="	etuxsell1n@usgs.gov	",Age=  45  ,Height=    136 ,Weight=    97  ,UserID=    60  },
new UserInformation() { First_Name = "	Dita	", Last_Name="	Bawle	",Email="	dbawle1o@studiopress.com	",Age=  41  ,Height=    187 ,Weight=    61  ,UserID=    61  },
new UserInformation() { First_Name = "	Willdon	", Last_Name="	Grancher	",Email="	wgrancher1p@ocn.ne.jp	",Age=  63  ,Height=    153 ,Weight=    94  ,UserID=    62  },
new UserInformation() { First_Name = "	Raphael	", Last_Name="	Lawson	",Email="	rlawson1q@howstuffworks.com	",Age=  67  ,Height=    169 ,Weight=    67  ,UserID=    63  },
new UserInformation() { First_Name = "	Jacky	", Last_Name="	Rickword	",Email="	jrickword1r@printfriendly.com	",Age=  34  ,Height=    132 ,Weight=    55  ,UserID=    64  },
new UserInformation() { First_Name = "	Tomi	", Last_Name="	Fludgate	",Email="	tfludgate1s@discovery.com	",Age=  54  ,Height=    179 ,Weight=    62  ,UserID=    65  },
new UserInformation() { First_Name = "	Aldo	", Last_Name="	Gammet	",Email="	agammet1t@parallels.com	",Age=  24  ,Height=    171 ,Weight=    84  ,UserID=    66  },
new UserInformation() { First_Name = "	Brannon	", Last_Name="	Bagshawe	",Email="	bbagshawe1u@skype.com	",Age=  61  ,Height=    148 ,Weight=    79  ,UserID=    67  },
new UserInformation() { First_Name = "	Paige	", Last_Name="	Allsop	",Email="	pallsop1v@telegraph.co.uk	",Age=  37  ,Height=    191 ,Weight=    52  ,UserID=    68  },
new UserInformation() { First_Name = "	Quintilla	", Last_Name="	Keable	",Email="	qkeable1w@quantcast.com	",Age=  50  ,Height=    199 ,Weight=    89  ,UserID=    69  },
new UserInformation() { First_Name = "	Ora	", Last_Name="	Lisamore	",Email="	olisamore1x@friendfeed.com	",Age=  19  ,Height=    190 ,Weight=    86  ,UserID=    70  },
new UserInformation() { First_Name = "	Norma	", Last_Name="	Gyrgorwicx	",Email="	ngyrgorwicx1y@nydailynews.com	",Age=  55  ,Height=    134 ,Weight=    71  ,UserID=    71  },
new UserInformation() { First_Name = "	Jamill	", Last_Name="	Gilchrist	",Email="	jgilchrist1z@livejournal.com	",Age=  55  ,Height=    146 ,Weight=    104 ,UserID=    72  },
new UserInformation() { First_Name = "	Westleigh	", Last_Name="	Baseggio	",Email="	wbaseggio20@about.me	",Age=  42  ,Height=    149 ,Weight=    103 ,UserID=    73  },
new UserInformation() { First_Name = "	Steffi	", Last_Name="	O'Breen	",Email="	sobreen21@ucla.edu	",Age=  37  ,Height=    182 ,Weight=    67  ,UserID=    74  },
new UserInformation() { First_Name = "	Noellyn	", Last_Name="	Bugden	",Email="	nbugden22@google.com.br	",Age=  44  ,Height=    138 ,Weight=    98  ,UserID=    75  },
new UserInformation() { First_Name = "	Hallie	", Last_Name="	Borwick	",Email="	hborwick23@smh.com.au	",Age=  65  ,Height=    173 ,Weight=    89  ,UserID=    76  },
new UserInformation() { First_Name = "	Fayina	", Last_Name="	Petow	",Email="	fpetow24@sfgate.com	",Age=  68  ,Height=    165 ,Weight=    83  ,UserID=    77  },
new UserInformation() { First_Name = "	Jonathon	", Last_Name="	Clitsome	",Email="	jclitsome25@pinterest.com	",Age=  43  ,Height=    169 ,Weight=    107 ,UserID=    78  },
new UserInformation() { First_Name = "	Syman	", Last_Name="	Tett	",Email="	stett26@google.co.jp	",Age=  43  ,Height=    172 ,Weight=    93  ,UserID=    79  },
new UserInformation() { First_Name = "	Ileana	", Last_Name="	Gaiford	",Email="	igaiford27@jalbum.net	",Age=  43  ,Height=    151 ,Weight=    92  ,UserID=    80  },
new UserInformation() { First_Name = "	Bobbi	", Last_Name="	Jobke	",Email="	bjobke28@pagesperso-orange.fr	",Age=  41  ,Height=    141 ,Weight=    55  ,UserID=    81  },
new UserInformation() { First_Name = "	Garrek	", Last_Name="	Danzelman	",Email="	gdanzelman29@omniture.com	",Age=  31  ,Height=    151 ,Weight=    101 ,UserID=    82  },
new UserInformation() { First_Name = "	Bili	", Last_Name="	Swepstone	",Email="	bswepstone2a@bigcartel.com	",Age=  40  ,Height=    195 ,Weight=    110 ,UserID=    83  },
new UserInformation() { First_Name = "	Desmund	", Last_Name="	Towndrow	",Email="	dtowndrow2b@desdev.cn	",Age=  24  ,Height=    196 ,Weight=    89  ,UserID=    84  },
new UserInformation() { First_Name = "	Clare	", Last_Name="	Knocker	",Email="	cknocker2c@dagondesign.com	",Age=  23  ,Height=    123 ,Weight=    67  ,UserID=    85  },
new UserInformation() { First_Name = "	Enos	", Last_Name="	Moy	",Email="	emoy2d@unicef.org	",Age=  57  ,Height=    122 ,Weight=    59  ,UserID=    86  },
new UserInformation() { First_Name = "	Lauren	", Last_Name="	Scawton	",Email="	lscawton2e@yandex.ru	",Age=  61  ,Height=    170 ,Weight=    89  ,UserID=    87  },
new UserInformation() { First_Name = "	Dionis	", Last_Name="	Winks	",Email="	dwinks2f@stumbleupon.com	",Age=  37  ,Height=    190 ,Weight=    55  ,UserID=    88  },
new UserInformation() { First_Name = "	Atlante	", Last_Name="	Edsall	",Email="	aedsall2g@rakuten.co.jp	",Age=  47  ,Height=    123 ,Weight=    107 ,UserID=    89  },
new UserInformation() { First_Name = "	Paco	", Last_Name="	Fairburn	",Email="	pfairburn2h@domainmarket.com	",Age=  46  ,Height=    183 ,Weight=    50  ,UserID=    90  },
new UserInformation() { First_Name = "	Emanuele	", Last_Name="	Dwyr	",Email="	edwyr2i@disqus.com	",Age=  39  ,Height=    168 ,Weight=    59  ,UserID=    91  },
new UserInformation() { First_Name = "	Nowell	", Last_Name="	Looney	",Email="	nlooney2j@infoseek.co.jp	",Age=  18  ,Height=    140 ,Weight=    63  ,UserID=    92  },
new UserInformation() { First_Name = "	Garvey	", Last_Name="	Laurie	",Email="	glaurie2k@mapquest.com	",Age=  21  ,Height=    143 ,Weight=    66  ,UserID=    93  },
new UserInformation() { First_Name = "	Mohammed	", Last_Name="	Condy	",Email="	mcondy2l@independent.co.uk	",Age=  34  ,Height=    171 ,Weight=    71  ,UserID=    94  },
new UserInformation() { First_Name = "	Dominique	", Last_Name="	Brownett	",Email="	dbrownett2m@drupal.org	",Age=  25  ,Height=    179 ,Weight=    66  ,UserID=    95  },
new UserInformation() { First_Name = "	Fredek	", Last_Name="	Wallice	",Email="	fwallice2n@zimbio.com	",Age=  37  ,Height=    163 ,Weight=    77  ,UserID=    96  },
new UserInformation() { First_Name = "	Vito	", Last_Name="	Ferran	",Email="	vferran2o@archive.org	",Age=  65  ,Height=    148 ,Weight=    54  ,UserID=    97  },
new UserInformation() { First_Name = "	Caddric	", Last_Name="	Pilbury	",Email="	cpilbury2p@arstechnica.com	",Age=  54  ,Height=    170 ,Weight=    77  ,UserID=    98  },
new UserInformation() { First_Name = "	Mack	", Last_Name="	Server	",Email="	mserver2q@goo.ne.jp	",Age=  22  ,Height=    142 ,Weight=    51  ,UserID=    99  },
new UserInformation() { First_Name = "	Brion	", Last_Name="	McQuaide	",Email="	bmcquaide2r@ning.com	",Age=  34  ,Height=    141 ,Weight=    54  ,UserID=    100 }


        };


            PasswordSecurity pass1 = new PasswordSecurity() { PasswordID = 01, UserID = 01, TotallySecureVeryHashedPassword = "pass" };
            PasswordSecurity pass2 = new PasswordSecurity() { PasswordID = 02, UserID = 02, TotallySecureVeryHashedPassword = "pass" };
            PasswordSecurity pass3 = new PasswordSecurity() { PasswordID = 03, UserID = 03, TotallySecureVeryHashedPassword = "pass" };
            PasswordSecurity pass4 = new PasswordSecurity() { PasswordID = 04, UserID = 04, TotallySecureVeryHashedPassword = "pass" };

            List<RunInformation> lista3 = new List<RunInformation>()
            {
new RunInformation(){ RunID=    1   ,UserID=    30  ,Distance=  7.9 ,Time="00:85:43"},
new RunInformation(){ RunID=    2   ,UserID=    67  ,Distance=  28.9    ,Time="00:29:95"},
new RunInformation(){ RunID=    3   ,UserID=    91  ,Distance=  17.2    ,Time="00:01:51"},
new RunInformation(){ RunID=    4   ,UserID=    89  ,Distance=  90  ,Time="00:69:03"},
new RunInformation(){ RunID=    5   ,UserID=    86  ,Distance=  16.1    ,Time="00:35:90"},
new RunInformation(){ RunID=    6   ,UserID=    41  ,Distance=  14.9    ,Time="00:79:63"},
new RunInformation(){ RunID=    7   ,UserID=    61  ,Distance=  77.5    ,Time="00:46:62"},
new RunInformation(){ RunID=    8   ,UserID=    43  ,Distance=  64.7    ,Time="00:01:78"},
new RunInformation(){ RunID=    9   ,UserID=    100 ,Distance=  63  ,Time="00:36:09"},
new RunInformation(){ RunID=    10  ,UserID=    43  ,Distance=  3.5 ,Time="00:45:46"},
new RunInformation(){ RunID=    11  ,UserID=    96  ,Distance=  72.7    ,Time="00:13:96"},
new RunInformation(){ RunID=    12  ,UserID=    15  ,Distance=  20.9    ,Time="00:04:38"},
new RunInformation(){ RunID=    13  ,UserID=    39  ,Distance=  5.7 ,Time="00:23:32"},
new RunInformation(){ RunID=    14  ,UserID=    96  ,Distance=  56.1    ,Time="00:73:56"},
new RunInformation(){ RunID=    15  ,UserID=    20  ,Distance=  19.4    ,Time="00:27:35"},
new RunInformation(){ RunID=    16  ,UserID=    35  ,Distance=  97  ,Time="00:49:60"},
new RunInformation(){ RunID=    17  ,UserID=    76  ,Distance=  28.9    ,Time="00:18:05"},
new RunInformation(){ RunID=    18  ,UserID=    2   ,Distance=  68.6    ,Time="00:81:06"},
new RunInformation(){ RunID=    19  ,UserID=    97  ,Distance=  82.8    ,Time="00:07:60"},
new RunInformation(){ RunID=    20  ,UserID=    51  ,Distance=  93.6    ,Time="00:87:13"},
new RunInformation(){ RunID=    21  ,UserID=    13  ,Distance=  95.8    ,Time="00:76:27"},
new RunInformation(){ RunID=    22  ,UserID=    10  ,Distance=  15.4    ,Time="00:03:38"},
new RunInformation(){ RunID=    23  ,UserID=    70  ,Distance=  75  ,Time="00:38:09"},
new RunInformation(){ RunID=    24  ,UserID=    50  ,Distance=  91  ,Time="00:28:48"},
new RunInformation(){ RunID=    25  ,UserID=    41  ,Distance=  31.4    ,Time="00:91:88"},
new RunInformation(){ RunID=    26  ,UserID=    2   ,Distance=  41.1    ,Time="00:57:99"},
new RunInformation(){ RunID=    27  ,UserID=    91  ,Distance=  19.4    ,Time="00:52:70"},
new RunInformation(){ RunID=    28  ,UserID=    93  ,Distance=  89.9    ,Time="00:95:20"},
new RunInformation(){ RunID=    29  ,UserID=    48  ,Distance=  10.8    ,Time="00:87:42"},
new RunInformation(){ RunID=    30  ,UserID=    49  ,Distance=  30.2    ,Time="00:91:22"},
new RunInformation(){ RunID=    31  ,UserID=    78  ,Distance=  96.9    ,Time="00:34:06"},
new RunInformation(){ RunID=    32  ,UserID=    40  ,Distance=  6.4 ,Time="00:86:85"},
new RunInformation(){ RunID=    33  ,UserID=    72  ,Distance=  6.6 ,Time="00:95:41"},
new RunInformation(){ RunID=    34  ,UserID=    11  ,Distance=  64.9    ,Time="00:12:46"},
new RunInformation(){ RunID=    35  ,UserID=    88  ,Distance=  78.1    ,Time="00:34:49"},
new RunInformation(){ RunID=    36  ,UserID=    82  ,Distance=  53.9    ,Time="00:53:13"},
new RunInformation(){ RunID=    37  ,UserID=    94  ,Distance=  75.4    ,Time="00:07:12"},
new RunInformation(){ RunID=    38  ,UserID=    53  ,Distance=  68.4    ,Time="00:18:03"},
new RunInformation(){ RunID=    39  ,UserID=    41  ,Distance=  8.3 ,Time="00:70:82"},
new RunInformation(){ RunID=    40  ,UserID=    67  ,Distance=  92.4    ,Time="00:17:47"},
new RunInformation(){ RunID=    41  ,UserID=    85  ,Distance=  35.4    ,Time="00:84:54"},
new RunInformation(){ RunID=    42  ,UserID=    53  ,Distance=  17.8    ,Time="00:12:56"},
new RunInformation(){ RunID=    43  ,UserID=    57  ,Distance=  51.2    ,Time="00:76:03"},
new RunInformation(){ RunID=    44  ,UserID=    72  ,Distance=  24  ,Time="00:69:59"},
new RunInformation(){ RunID=    45  ,UserID=    28  ,Distance=  72.2    ,Time="00:48:93"},
new RunInformation(){ RunID=    46  ,UserID=    26  ,Distance=  78.6    ,Time="00:43:29"},
new RunInformation(){ RunID=    47  ,UserID=    25  ,Distance=  2.2 ,Time="00:63:13"},
new RunInformation(){ RunID=    48  ,UserID=    61  ,Distance=  87.3    ,Time="00:58:60"},
new RunInformation(){ RunID=    49  ,UserID=    44  ,Distance=  88.7    ,Time="00:80:72"},
new RunInformation(){ RunID=    50  ,UserID=    84  ,Distance=  3   ,Time="00:43:85"},
new RunInformation(){ RunID=    51  ,UserID=    98  ,Distance=  37.9    ,Time="00:75:65"},
new RunInformation(){ RunID=    52  ,UserID=    29  ,Distance=  36.4    ,Time="00:08:48"},
new RunInformation(){ RunID=    53  ,UserID=    3   ,Distance=  15  ,Time="00:49:31"},
new RunInformation(){ RunID=    54  ,UserID=    78  ,Distance=  7.3 ,Time="00:81:81"},
new RunInformation(){ RunID=    55  ,UserID=    37  ,Distance=  9.9 ,Time="00:66:84"},
new RunInformation(){ RunID=    56  ,UserID=    90  ,Distance=  85.5    ,Time="00:18:03"},
new RunInformation(){ RunID=    57  ,UserID=    18  ,Distance=  24  ,Time="00:36:43"},
new RunInformation(){ RunID=    58  ,UserID=    5   ,Distance=  72.8    ,Time="00:64:74"},
new RunInformation(){ RunID=    59  ,UserID=    85  ,Distance=  24.7    ,Time="00:91:48"},
new RunInformation(){ RunID=    60  ,UserID=    5   ,Distance=  54.6    ,Time="00:98:47"},
new RunInformation(){ RunID=    61  ,UserID=    10  ,Distance=  75.4    ,Time="00:04:95"},
new RunInformation(){ RunID=    62  ,UserID=    92  ,Distance=  18.7    ,Time="00:67:82"},
new RunInformation(){ RunID=    63  ,UserID=    27  ,Distance=  20.5    ,Time="00:47:45"},
new RunInformation(){ RunID=    64  ,UserID=    62  ,Distance=  51.8    ,Time="00:79:59"},
new RunInformation(){ RunID=    65  ,UserID=    62  ,Distance=  83.6    ,Time="00:55:16"},
new RunInformation(){ RunID=    66  ,UserID=    38  ,Distance=  5.1 ,Time="00:89:09"},
new RunInformation(){ RunID=    67  ,UserID=    30  ,Distance=  88.7    ,Time="00:36:43"},
new RunInformation(){ RunID=    68  ,UserID=    97  ,Distance=  76.7    ,Time="00:75:05"},
new RunInformation(){ RunID=    69  ,UserID=    48  ,Distance=  94.3    ,Time="00:47:28"},
new RunInformation(){ RunID=    70  ,UserID=    66  ,Distance=  8.3 ,Time="00:01:54"},
new RunInformation(){ RunID=    71  ,UserID=    87  ,Distance=  83  ,Time="00:07:25"},
new RunInformation(){ RunID=    72  ,UserID=    52  ,Distance=  32.8    ,Time="00:00:67"},
new RunInformation(){ RunID=    73  ,UserID=    27  ,Distance=  94  ,Time="00:13:17"},
new RunInformation(){ RunID=    74  ,UserID=    29  ,Distance=  75.4    ,Time="00:68:37"},
new RunInformation(){ RunID=    75  ,UserID=    74  ,Distance=  16.4    ,Time="00:34:49"},
new RunInformation(){ RunID=    76  ,UserID=    24  ,Distance=  74.8    ,Time="00:11:15"},
new RunInformation(){ RunID=    77  ,UserID=    35  ,Distance=  3.4 ,Time="00:25:21"},
new RunInformation(){ RunID=    78  ,UserID=    44  ,Distance=  97.2    ,Time="00:59:93"},
new RunInformation(){ RunID=    79  ,UserID=    73  ,Distance=  56.1    ,Time="00:87:44"},
new RunInformation(){ RunID=    80  ,UserID=    79  ,Distance=  64.9    ,Time="00:48:01"},
new RunInformation(){ RunID=    81  ,UserID=    64  ,Distance=  45  ,Time="00:02:63"},
new RunInformation(){ RunID=    82  ,UserID=    30  ,Distance=  0.1 ,Time="00:01:10"},
new RunInformation(){ RunID=    83  ,UserID=    97  ,Distance=  15.2    ,Time="00:87:60"},
new RunInformation(){ RunID=    84  ,UserID=    36  ,Distance=  42.2    ,Time="00:37:13"},
new RunInformation(){ RunID=    85  ,UserID=    97  ,Distance=  45.5    ,Time="00:21:81"},
new RunInformation(){ RunID=    86  ,UserID=    8   ,Distance=  5.7 ,Time="00:46:45"},
new RunInformation(){ RunID=    87  ,UserID=    42  ,Distance=  7.8 ,Time="00:41:64"},
new RunInformation(){ RunID=    88  ,UserID=    62  ,Distance=  98.6    ,Time="00:93:68"},
new RunInformation(){ RunID=    89  ,UserID=    76  ,Distance=  34.2    ,Time="00:27:28"},
new RunInformation(){ RunID=    90  ,UserID=    22  ,Distance=  89.1    ,Time="00:76:61"},
new RunInformation(){ RunID=    91  ,UserID=    41  ,Distance=  9.6 ,Time="00:12:23"},
new RunInformation(){ RunID=    92  ,UserID=    32  ,Distance=  50.6    ,Time="00:28:73"},
new RunInformation(){ RunID=    93  ,UserID=    17  ,Distance=  73  ,Time="00:00:37"},
new RunInformation(){ RunID=    94  ,UserID=    86  ,Distance=  26.6    ,Time="00:33:95"},
new RunInformation(){ RunID=    95  ,UserID=    78  ,Distance=  93.5    ,Time="00:36:11"},
new RunInformation(){ RunID=    96  ,UserID=    47  ,Distance=  34.5    ,Time="00:98:95"},
new RunInformation(){ RunID=    97  ,UserID=    97  ,Distance=  36.4    ,Time="00:85:08"},
new RunInformation(){ RunID=    98  ,UserID=    10  ,Distance=  97.2    ,Time="00:46:83"},
new RunInformation(){ RunID=    99  ,UserID=    48  ,Distance=  23.3    ,Time="00:70:92"},
new RunInformation(){ RunID=    100 ,UserID=    92  ,Distance=  80.3    ,Time="00:72:34"},
new RunInformation(){ RunID=    101 ,UserID=    18  ,Distance=  48.8    ,Time="00:36:83"},
new RunInformation(){ RunID=    102 ,UserID=    56  ,Distance=  96.9    ,Time="00:55:53"},
new RunInformation(){ RunID=    103 ,UserID=    91  ,Distance=  7.8 ,Time="00:50:50"},
new RunInformation(){ RunID=    104 ,UserID=    27  ,Distance=  20.3    ,Time="00:80:93"},
new RunInformation(){ RunID=    105 ,UserID=    57  ,Distance=  9.9 ,Time="00:81:53"},
new RunInformation(){ RunID=    106 ,UserID=    87  ,Distance=  74.9    ,Time="00:39:61"},
new RunInformation(){ RunID=    107 ,UserID=    12  ,Distance=  96.6    ,Time="00:15:23"},
new RunInformation(){ RunID=    108 ,UserID=    42  ,Distance=  61.2    ,Time="00:92:66"},
new RunInformation(){ RunID=    109 ,UserID=    65  ,Distance=  94.1    ,Time="00:73:85"},
new RunInformation(){ RunID=    110 ,UserID=    94  ,Distance=  97.2    ,Time="00:63:84"},
new RunInformation(){ RunID=    111 ,UserID=    39  ,Distance=  38.3    ,Time="00:41:34"},
new RunInformation(){ RunID=    112 ,UserID=    35  ,Distance=  62.6    ,Time="00:63:21"},
new RunInformation(){ RunID=    113 ,UserID=    12  ,Distance=  43.1    ,Time="00:58:43"},
new RunInformation(){ RunID=    114 ,UserID=    66  ,Distance=  3   ,Time="00:69:88"},
new RunInformation(){ RunID=    115 ,UserID=    99  ,Distance=  72.3    ,Time="00:95:72"},
new RunInformation(){ RunID=    116 ,UserID=    61  ,Distance=  48.7    ,Time="00:44:04"},
new RunInformation(){ RunID=    117 ,UserID=    30  ,Distance=  29.3    ,Time="00:68:01"},
new RunInformation(){ RunID=    118 ,UserID=    45  ,Distance=  89.8    ,Time="00:71:63"},
new RunInformation(){ RunID=    119 ,UserID=    48  ,Distance=  81.2    ,Time="00:53:71"},
new RunInformation(){ RunID=    120 ,UserID=    23  ,Distance=  79.4    ,Time="00:36:78"},
new RunInformation(){ RunID=    121 ,UserID=    41  ,Distance=  30  ,Time="00:30:03"},
new RunInformation(){ RunID=    122 ,UserID=    95  ,Distance=  30.4    ,Time="00:00:12"},
new RunInformation(){ RunID=    123 ,UserID=    93  ,Distance=  49.1    ,Time="00:53:38"},
new RunInformation(){ RunID=    124 ,UserID=    99  ,Distance=  3   ,Time="00:55:03"},
new RunInformation(){ RunID=    125 ,UserID=    92  ,Distance=  68.7    ,Time="00:95:34"},
new RunInformation(){ RunID=    126 ,UserID=    62  ,Distance=  65.6    ,Time="00:85:32"},
new RunInformation(){ RunID=    127 ,UserID=    35  ,Distance=  44.1    ,Time="00:03:74"},
new RunInformation(){ RunID=    128 ,UserID=    36  ,Distance=  22.5    ,Time="00:69:65"},
new RunInformation(){ RunID=    129 ,UserID=    85  ,Distance=  49.1    ,Time="00:56:83"},
new RunInformation(){ RunID=    130 ,UserID=    45  ,Distance=  12.6    ,Time="00:44:82"},
new RunInformation(){ RunID=    131 ,UserID=    33  ,Distance=  30.2    ,Time="00:34:69"},
new RunInformation(){ RunID=    132 ,UserID=    19  ,Distance=  67.3    ,Time="00:13:00"},
new RunInformation(){ RunID=    133 ,UserID=    23  ,Distance=  57.8    ,Time="00:15:01"},
new RunInformation(){ RunID=    134 ,UserID=    13  ,Distance=  39.4    ,Time="00:30:62"},
new RunInformation(){ RunID=    135 ,UserID=    43  ,Distance=  21.3    ,Time="00:28:67"},
new RunInformation(){ RunID=    136 ,UserID=    51  ,Distance=  25.1    ,Time="00:65:60"},
new RunInformation(){ RunID=    137 ,UserID=    50  ,Distance=  88.8    ,Time="00:05:51"},
new RunInformation(){ RunID=    138 ,UserID=    99  ,Distance=  37.9    ,Time="00:91:38"},
new RunInformation(){ RunID=    139 ,UserID=    33  ,Distance=  35.1    ,Time="00:66:28"},
new RunInformation(){ RunID=    140 ,UserID=    12  ,Distance=  86.9    ,Time="00:92:00"},
new RunInformation(){ RunID=    141 ,UserID=    86  ,Distance=  11.5    ,Time="00:19:20"},
new RunInformation(){ RunID=    142 ,UserID=    70  ,Distance=  6.4 ,Time="00:88:00"},
new RunInformation(){ RunID=    143 ,UserID=    24  ,Distance=  18.5    ,Time="00:57:41"},
new RunInformation(){ RunID=    144 ,UserID=    77  ,Distance=  92.7    ,Time="00:52:35"},
new RunInformation(){ RunID=    145 ,UserID=    89  ,Distance=  75.6    ,Time="00:72:52"},
new RunInformation(){ RunID=    146 ,UserID=    66  ,Distance=  10.3    ,Time="00:98:17"},
new RunInformation(){ RunID=    147 ,UserID=    94  ,Distance=  91.3    ,Time="00:39:86"},
new RunInformation(){ RunID=    148 ,UserID=    19  ,Distance=  63  ,Time="00:25:84"},
new RunInformation(){ RunID=    149 ,UserID=    39  ,Distance=  64.2    ,Time="00:89:66"},
new RunInformation(){ RunID=    150 ,UserID=    89  ,Distance=  18.8    ,Time="00:91:13"},
new RunInformation(){ RunID=    151 ,UserID=    10  ,Distance=  90.2    ,Time="00:53:34"},
new RunInformation(){ RunID=    152 ,UserID=    8   ,Distance=  77.7    ,Time="00:83:08"},
new RunInformation(){ RunID=    153 ,UserID=    59  ,Distance=  70.7    ,Time="00:27:11"},
new RunInformation(){ RunID=    154 ,UserID=    14  ,Distance=  7.5 ,Time="00:45:21"},
new RunInformation(){ RunID=    155 ,UserID=    14  ,Distance=  39.7    ,Time="00:80:60"},
new RunInformation(){ RunID=    156 ,UserID=    73  ,Distance=  23.6    ,Time="00:10:87"},
new RunInformation(){ RunID=    157 ,UserID=    68  ,Distance=  76  ,Time="00:58:56"},
new RunInformation(){ RunID=    158 ,UserID=    93  ,Distance=  18.6    ,Time="00:74:97"},
new RunInformation(){ RunID=    159 ,UserID=    43  ,Distance=  29.9    ,Time="00:49:86"},
new RunInformation(){ RunID=    160 ,UserID=    44  ,Distance=  79.3    ,Time="00:65:13"},
new RunInformation(){ RunID=    161 ,UserID=    79  ,Distance=  98.9    ,Time="00:84:81"},
new RunInformation(){ RunID=    162 ,UserID=    3   ,Distance=  34.1    ,Time="00:24:99"},
new RunInformation(){ RunID=    163 ,UserID=    15  ,Distance=  84.9    ,Time="00:16:31"},
new RunInformation(){ RunID=    164 ,UserID=    21  ,Distance=  41.7    ,Time="00:38:11"},
new RunInformation(){ RunID=    165 ,UserID=    94  ,Distance=  80.9    ,Time="00:14:74"},
new RunInformation(){ RunID=    166 ,UserID=    4   ,Distance=  44.2    ,Time="00:16:73"},
new RunInformation(){ RunID=    167 ,UserID=    73  ,Distance=  73.5    ,Time="00:10:88"},
new RunInformation(){ RunID=    168 ,UserID=    52  ,Distance=  26.7    ,Time="00:99:64"},
new RunInformation(){ RunID=    169 ,UserID=    19  ,Distance=  71.4    ,Time="00:36:69"},
new RunInformation(){ RunID=    170 ,UserID=    16  ,Distance=  1   ,Time="00:25:08"},
new RunInformation(){ RunID=    171 ,UserID=    58  ,Distance=  63.3    ,Time="00:15:23"},
new RunInformation(){ RunID=    172 ,UserID=    42  ,Distance=  91.3    ,Time="00:16:06"},
new RunInformation(){ RunID=    173 ,UserID=    84  ,Distance=  62.5    ,Time="00:19:36"},
new RunInformation(){ RunID=    174 ,UserID=    19  ,Distance=  54.5    ,Time="00:06:85"},
new RunInformation(){ RunID=    175 ,UserID=    63  ,Distance=  5.4 ,Time="00:16:27"},
new RunInformation(){ RunID=    176 ,UserID=    57  ,Distance=  84  ,Time="00:72:98"},
new RunInformation(){ RunID=    177 ,UserID=    34  ,Distance=  60.8    ,Time="00:61:33"},
new RunInformation(){ RunID=    178 ,UserID=    35  ,Distance=  33.3    ,Time="00:44:76"},
new RunInformation(){ RunID=    179 ,UserID=    45  ,Distance=  93.4    ,Time="00:03:50"},
new RunInformation(){ RunID=    180 ,UserID=    61  ,Distance=  89.8    ,Time="00:20:64"},
new RunInformation(){ RunID=    181 ,UserID=    5   ,Distance=  39  ,Time="00:20:45"},
new RunInformation(){ RunID=    182 ,UserID=    10  ,Distance=  29.2    ,Time="00:98:56"},
new RunInformation(){ RunID=    183 ,UserID=    99  ,Distance=  93.9    ,Time="00:08:01"},
new RunInformation(){ RunID=    184 ,UserID=    27  ,Distance=  41.3    ,Time="00:38:15"},
new RunInformation(){ RunID=    185 ,UserID=    16  ,Distance=  35.9    ,Time="00:50:64"},
new RunInformation(){ RunID=    186 ,UserID=    36  ,Distance=  15.8    ,Time="00:28:57"},
new RunInformation(){ RunID=    187 ,UserID=    56  ,Distance=  95.8    ,Time="00:78:97"},
new RunInformation(){ RunID=    188 ,UserID=    50  ,Distance=  4.5 ,Time="00:71:19"},
new RunInformation(){ RunID=    189 ,UserID=    34  ,Distance=  12.8    ,Time="00:02:03"},
new RunInformation(){ RunID=    190 ,UserID=    24  ,Distance=  13.6    ,Time="00:61:12"},
new RunInformation(){ RunID=    191 ,UserID=    83  ,Distance=  50  ,Time="00:19:44"},
new RunInformation(){ RunID=    192 ,UserID=    94  ,Distance=  18.9    ,Time="00:50:74"},
new RunInformation(){ RunID=    193 ,UserID=    4   ,Distance=  5.8 ,Time="00:20:35"},
new RunInformation(){ RunID=    194 ,UserID=    32  ,Distance=  18.5    ,Time="00:89:10"},
new RunInformation(){ RunID=    195 ,UserID=    45  ,Distance=  33.8    ,Time="00:24:18"},
new RunInformation(){ RunID=    196 ,UserID=    77  ,Distance=  60.6    ,Time="00:94:62"},
new RunInformation(){ RunID=    197 ,UserID=    34  ,Distance=  1.4 ,Time="00:31:08"},
new RunInformation(){ RunID=    198 ,UserID=    76  ,Distance=  8.4 ,Time="00:93:81"},
new RunInformation(){ RunID=    199 ,UserID=    59  ,Distance=  21.6    ,Time="00:54:34"},
new RunInformation(){ RunID=    200 ,UserID=    28  ,Distance=  31  ,Time="00:58:61"},
new RunInformation(){ RunID=    201 ,UserID=    46  ,Distance=  77.8    ,Time="00:07:08"},
new RunInformation(){ RunID=    202 ,UserID=    11  ,Distance=  61.2    ,Time="00:14:92"},
new RunInformation(){ RunID=    203 ,UserID=    51  ,Distance=  24  ,Time="00:19:57"},
new RunInformation(){ RunID=    204 ,UserID=    11  ,Distance=  33.4    ,Time="00:34:44"},
new RunInformation(){ RunID=    205 ,UserID=    52  ,Distance=  68.2    ,Time="00:76:05"},
new RunInformation(){ RunID=    206 ,UserID=    31  ,Distance=  45.7    ,Time="00:21:48"},
new RunInformation(){ RunID=    207 ,UserID=    69  ,Distance=  70.8    ,Time="00:56:63"},
new RunInformation(){ RunID=    208 ,UserID=    1   ,Distance=  51.3    ,Time="00:87:38"},
new RunInformation(){ RunID=    209 ,UserID=    35  ,Distance=  24.3    ,Time="00:45:71"},
new RunInformation(){ RunID=    210 ,UserID=    54  ,Distance=  39.4    ,Time="00:05:70"},
new RunInformation(){ RunID=    211 ,UserID=    26  ,Distance=  41.1    ,Time="00:78:06"},
new RunInformation(){ RunID=    212 ,UserID=    79  ,Distance=  6.9 ,Time="00:71:46"},
new RunInformation(){ RunID=    213 ,UserID=    76  ,Distance=  82  ,Time="00:20:67"},
new RunInformation(){ RunID=    214 ,UserID=    65  ,Distance=  78.3    ,Time="00:21:28"},
new RunInformation(){ RunID=    215 ,UserID=    94  ,Distance=  13.2    ,Time="00:95:48"},
new RunInformation(){ RunID=    216 ,UserID=    18  ,Distance=  52.1    ,Time="00:37:62"},
new RunInformation(){ RunID=    217 ,UserID=    52  ,Distance=  10  ,Time="00:17:61"},
new RunInformation(){ RunID=    218 ,UserID=    28  ,Distance=  59.1    ,Time="00:92:67"},
new RunInformation(){ RunID=    219 ,UserID=    36  ,Distance=  89.9    ,Time="00:73:44"},
new RunInformation(){ RunID=    220 ,UserID=    100 ,Distance=  68.9    ,Time="00:61:52"},
new RunInformation(){ RunID=    221 ,UserID=    66  ,Distance=  70.5    ,Time="00:97:54"},
new RunInformation(){ RunID=    222 ,UserID=    44  ,Distance=  97  ,Time="00:36:54"},
new RunInformation(){ RunID=    223 ,UserID=    48  ,Distance=  60  ,Time="00:82:08"},
new RunInformation(){ RunID=    224 ,UserID=    56  ,Distance=  17.7    ,Time="00:82:36"},
new RunInformation(){ RunID=    225 ,UserID=    12  ,Distance=  23.8    ,Time="00:44:09"},
new RunInformation(){ RunID=    226 ,UserID=    38  ,Distance=  25  ,Time="00:82:49"},
new RunInformation(){ RunID=    227 ,UserID=    26  ,Distance=  32.1    ,Time="00:82:37"},
new RunInformation(){ RunID=    228 ,UserID=    13  ,Distance=  86.6    ,Time="00:88:00"},
new RunInformation(){ RunID=    229 ,UserID=    86  ,Distance=  32.8    ,Time="00:90:62"},
new RunInformation(){ RunID=    230 ,UserID=    94  ,Distance=  15.3    ,Time="00:93:75"},
new RunInformation(){ RunID=    231 ,UserID=    4   ,Distance=  60  ,Time="00:61:22"},
new RunInformation(){ RunID=    232 ,UserID=    68  ,Distance=  81.7    ,Time="00:89:48"},
new RunInformation(){ RunID=    233 ,UserID=    32  ,Distance=  91.6    ,Time="00:32:38"},
new RunInformation(){ RunID=    234 ,UserID=    72  ,Distance=  73.9    ,Time="00:15:96"}

            };

            

            modelBuilder.Entity<RunInformation>().HasData(lista3);
            modelBuilder.Entity<PasswordSecurity>().HasData(pass1, pass2, pass3, pass4);
            modelBuilder.Entity<UserInformation>().HasData(listau);



            #region commented outmight needed later


            //use.Users.Add(new UserInformation() { UserID = 01, Weight = 77 });
            //use.Users.Add(new UserInformation() { UserID = 02, Weight = 55 });
            //use.Users.Add(new UserInformation() { UserID = 03, Weight = 79 });
            //use.Users.Add(new UserInformation() { UserID = 04, Weight = 87 });

            //use.SaveChanges();


            //PasswordSecurityContext pass = new PasswordSecurityContext();
            //pass.Passwords.Add(new PasswordSecurity() { UserID = 01, TotallySecureVeryHashedPassword = "1234" });
            //pass.Passwords.Add(new PasswordSecurity() { UserID = 02, TotallySecureVeryHashedPassword = "1234" });
            //pass.Passwords.Add(new PasswordSecurity() { UserID = 03, TotallySecureVeryHashedPassword = "1234" });
            //pass.Passwords.Add(new PasswordSecurity() { UserID = 04, TotallySecureVeryHashedPassword = "1234" });

            //pass.SaveChanges();

            //RunInformationContext run = new RunInformationContext();
            //run.Runs.Add(new RunInformation() { UserID = 01, Distance = 12.4, Time = "01:04:42" });
            //run.Runs.Add(new RunInformation() { UserID = 02, Distance = 6.5, Time = "00:32:12" });
            //run.Runs.Add(new RunInformation() { UserID = 03, Distance = 3.0, Time = "00:14:00" });
            //run.Runs.Add(new RunInformation() { UserID = 04, Distance = 22, Time = "03:22:02" });

            //run.SaveChanges();

            #endregion



        }

    }
}
