﻿int x,i,j,m,n,k,l,d;long e;d=1000000;z(2);z(d);void z(int h){e=x=i=j=m=n=k=l=0;var r=new bool[d];var c=new bool[d];List<Tuple<int,int>>g=new();using(StreamReader q=new(args[0]))do{x=q.Read();if(x>10){if(x==35){r[i]=c[j]=1>0;g.Add(new(i,j));}j++;}else{i++;j=0;}}while(x>0);x=g.Count;for(;j<x;j++)for(i=j+1;i<x;i++){(m,n)=g[j];(k,l)=g[i];while(m!=k)e+=r[m+=m<k?1:-1]?1:h;while(n!=l)e+=c[n+=n<l?1:-1]?1:h;}Console.WriteLine(e);}