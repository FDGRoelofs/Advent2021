import System.IO
import Control.Monad
import Data.Char
import Data.List
import System.Win32 (COORD(y, x))



main = print (length output1)

output1 = nub firstfold
output2 = sort (allfolds foldcommands inputpoints)

readInt :: String -> Int
readInt = read

absDiff :: Num a => a -> a -> a
absDiff n = abs . (n-)

findPoints :: String -> Bool 
findPoints x = isLetter (head x)

findFolds :: String -> Bool 
findFolds [] = False 
findFolds (x:xs) = 'f' == x

startPoints :: [Int] -> [(Int,Int)]
startPoints [] = []
startPoints (x:y:xs) =(x,y) : startPoints xs
startPoints _ = []

foldAny :: (Char,Int) -> (Int,Int)-> (Int,Int)
foldAny ('x',axis) point = foldLeft axis point
foldAny ('y',axis) point = foldUp axis point
foldAny _ _ = (9999999,999999)

foldLeft :: Int -> (Int,Int) -> (Int,Int)
foldLeft axis (x,y) 
    | x > axis =  (axis - absDiff x axis,y)
    | otherwise = (x,y)

foldUp :: Int -> (Int,Int) -> (Int,Int)
foldUp axis (x,y)
    | y > axis = (x,axis - absDiff y axis)
    | otherwise = (x,y)

inputpoints = startPoints startCoords

firstfold = map (foldAny ('x',655)) inputpoints

allfolds :: [(Char,Int)] -> [(Int,Int)] -> [(Int,Int)]
allfolds [] points = nub points 
allfolds (ins:rest) points = allfolds rest (nub $ map (foldAny ins) points) -- moet hier nog een nub in

startCoords = [1026,284,612,2,355,653,711,884,1205,14,971,348,550,313,1261,236,1155,838,33,487,1287,690,1230,722,1230,110,73,854,1178,81,216,719,875,794,900,334,1277,61,783,240,1099,159,303,528,624,327,108,322,698,444,990,397,1131,856,527,273,1195,831,1029,49,1220,688,177,724,671,478,1016,807,385,141,944,140,1084,525,984,893,1265,243,793,543,334,581,780,128,326,669,826,845,609,38,299,126,828,758,607,212,818,313,296,343,127,421,612,486,571,294,811,838,192,45,991,516,80,546,554,547,592,33,311,192,1237,488,1205,880,1131,605,542,410,344,674,284,284,326,569,976,581,1292,795,70,494,847,320,62,275,842,705,393,792,678,294,313,1,559,775,11,457,646,544,144,67,559,878,1066,782,492,549,45,682,1128,84,746,323,291,585,713,786,774,86,597,114,1005,75,488,446,94,527,269,589,423,617,258,591,395,23,1205,238,340,420,27,261,587,792,170,173,972,254,875,396,1131,528,850,2,892,94,490,873,1081,628,1041,254,925,219,1245,435,969,109,984,673,627,411,689,855,711,487,1294,668,209,18,981,2,885,360,1101,204,499,201,870,193,435,794,107,212,1210,99,639,864,445,18,564,766,127,660,1295,724,62,705,15,170,595,775,428,11,189,325,831,73,380,735,803,394,898,100,1243,344,1099,253,970,868,865,38,1227,854,0,542,490,318,831,821,373,428,1193,652,1074,542,483,133,1297,221,1108,729,726,848,705,684,202,506,397,793,536,86,684,401,1014,674,1206,313,1216,255,134,849,189,95,706,661,662,257,396,863,616,165,1017,285,917,254,475,500,377,658,231,103,261,550,1014,253,892,653,1265,341,492,245,1261,96,785,722,1170,362,933,210,268,112,961,75,1260,233,1253,667,848,849,1299,546,1036,159,1011,126,385,723,30,327,47,682,1309,208,522,793,406,570,592,189,499,873,1216,415,236,542,1183,869,586,59,564,284,130,807,490,128,870,253,666,780,1014,641,1133,170,1268,296,805,394,423,197,62,640,554,291,162,128,97,136,1041,589,644,478,739,600,202,729,937,362,1260,141,900,784,874,546,766,719,974,463,140,362,351,338,1033,236,915,863,97,696,386,784,62,702,370,200,277,236,800,84,1019,585,1213,422,999,590,564,653,274,719,179,366,791,768,1213,24,728,795,276,213,1248,204,279,178,887,276,609,856,383,39,522,81,1230,784,933,236,783,660,1190,162,1111,137,524,807,343,438,274,607,960,420,1277,385,1303,154,52,771,776,21,1084,291,795,752,358,551,502,338,564,654,197,498,694,165,1298,619,726,324,229,360,604,661,175,681,45,385,1265,354,1299,180,1155,693,38,378,1119,635,351,80,1134,499,530,542,607,570,898,336,494,448,124,240,530,352,209,316,216,175,845,325,433,753,281,10,970,420,756,547,1150,448,1300,332,990,133,120,162,1211,198,1041,108,1006,824,57,108,281,532,1227,600,0,38,248,324,701,38,874,644,1029,532,643,546,390,544,1074,459,771,417,701,89,93,429,522,529,219,407,254,99,435,851,1081,11,1034,141,440,865,967,273,644,561,560,255,811,761,643,714,335,628,527,654,991,826,269,780,1155,761,666,562,132,81,606,124,534,694,100,99,229,628,1310,466,1004,382,385,780,1186,318,1131,842,1197,135,179,842,698,2,175,821,226,603,932,690,776,648,621,285,445,876,1148,345,728,877,350,70,124,521,136,301,763,548,641,634,1026,532,1213,792,1257,821,1017,39,1213,266,724,59,1258,771,242,794,199,49,966,674,971,796,587,316,917,640,574,348,10,113,997,893,105,238,366,826,211,159,385,675,139,781,1248,189,684,45,1134,171,425,326,281,49,281,84,639,58,1171,304,1215,471,62,254,980,626,999,304,1022,364,621,833,1096,865,999,621,557,248,867,794,952,220,522,101,534,200,807,73,90,508,597,395,627,483,418,800,788,81,654,121,1166,532,62,749,105,14,1014,551,976,133,179,605,518,558,268,784,1156,798,818,766,346,756,246,336,59,103,1161,455,350,672,194,493,160,448,547,263,1245,584,780,364,311,456,428,413,892,205,310,738,530,766,97,430,1178,365,940,162,585,773,296,674,197,844,1263,212,45,877,177,170,254,599,999,276,739,114,269,227,1252,112,937,466,477,394,132,365,18,795,410,110,612,408,370,732,97,422,1248,749,339,42,780,542,811,348,557,136,263,472,154,798,574,558,527,212,1283,821,1222,397,294,359,956,294,455,397,373,84,1091,234,378,690,1121,569,1052,31,398,46,674,138,293,609,1300,751,139,590,776,694,1,226,1047,472,723,887,1253,114,589,94,780,318,45,540,315,348,1139,166,691,645,783,269,862,38,1178,450,15,724,992,462,229,180,1133,410,1238,547,530,318,124,542,541,759,1255,407,920,544,139,304,380,159,672,674,77,138,398,772,1215,327,77,756,694,427,776,226,1146,889,1275,297,343,273,664,798,535,72,1108,164,385,640,68,143,264,145,763,407,919,198,1220,571,436,644,314,868,669,484,339,98,1265,682,666,333,763,346,786,807,428,525,1176,849,1113,844,366,875,155,469,534,284,1294,786,477,113,115,570,648,313,1178,345,967,590,949,39,445,690,372,136,1277,487,209,486,57,780,984,876,396,591,375,255,1303,826,236,459,560,639,822,446,358,668,1074,94,833,394,753,459,1171,113,1220,123,299,521,599,487,326,893,16,108,99,696,1171,590,550,581,952,332,484,621,115,63,1158,445,219,234,1016,87,479,73,1005,819,32,87,130,87,416,721,780,373,350,420,1026,834,683,768,1094,47,393,542,557,292,246,768,385,499,221,141,1268,598,390,145,1041,590,959,338,1148,21,313,561,477,500,855,621,746,284,872,847,97,24,927,39,627,821,887,343,909,210,284,532,776,284,914,591,703,831,816,448,1260,661,1205,126,574,546,763,375,967,254,507,38,155,133,498,89,231,690,373,466,42,598,586,54,914,303,919,646,932,242,826,621,1252,782,514,705,933,535,105,880,1146,535,1,208,340,868,176,499,557,198,574,110,994,254,701,805,917,577,319,516,460,786,564,688,1230,558,1265,877,937,84,905,84,1186,206,952,551,633,595,277,210,667,9,18,99,246,322,1155,166,537,354,882,861,120,873,206,572,94,415,820,784,701,465,967,142,957,101,703,324,609,651,274,383,393,688,997,113,627,768,1213,214,974,350,418,206,296,641,246,558,1258,186,291,521,1248,254,536,808,47,212,1183,234,1042,110,156,89,152,21,127,436,587,887,833,113,1033,882,937,458,90,386,1036,735,638,108,947,309,15,836,400,795,107,498,326,18,194,625,1253,141,445,130,418,653,518,593,1242,751,171,728,18,771,65,352,47,324,1108,506,68,751,875,548,314,474,1108,165,709,821,140,189,1205,432,408,770,293,386,708,771,919,248,736,722,1233,756,736,348,1216,639,97,628,832,395,875,487,878,0,930,607,671,836,390,413,547,487,373,234,599,407,452,602,45,341,937,884,1283,633,269,108,831,521,751,343,52,571,981,238,90,123,288,19,818,245,1158,415,811,693,1272,50,783,436,1091,711,97,214,435,407,261,102,1056,99,788,549,656,121,301,351,423,103,162,649,1253,780,45,212,492,128,242,346,189,773,1042,784,1000,556,547,346,13,708,293,855,221,96,319,628,433,798,279,271,773,710,835,366,761,768,1061,532,55,212,1014,103,567,666,654,38,1198,410,503,73,343,254,288,530,803,856,805,439,372,758,12,275,530,373,358,332,689,61,296,114,1158,21,592,861,619,645,425,646,281,845,433,141,1241,325,154,544,721,94,1178,338,10,562,499,56,724,54,492,560,933,658,827,133,1081,360,1068,336,325,892,53,821,994,864,170,621,440,641,527,240,1297,673,1175,96,311,276,1183,421,858,602,1245,459,306,512,541,154,1123,304,1148,128,534,668,626,45,736,336,267,343,492,101,638,332,231,791,1108,542,1061,756,587,344,1178,556,713,114,361,855,244,602,1211,696,828,880,910,795,537,710,1288,196,164,318,304,420,65,584,1026,648,72,547,982,225,959,80,320,761,11,546,525,396,902,770,1183,436,984,18,820,873,492,345,999,456,862,892,1146,318,944,530,187,304,1047,696,971,98,1235,722,279,324,57,786,518,348,10,332,154,350,344,220,249,756,269,171,636,67,740,784,1186,542,1029,845,808,21,59,775,391,696,756,603,704,770,313,551,373,884,967,459,749,429,780,688,277,12,300,369,885,646,918,472,1041,171,606,770,277,882,425,86,1099,511,1056,599,1265,509,1033,12,1156,544,739,294,933,684,499,838,416,173,641,260,300,525,194,269,378,652,1163,285,713,443,281,18,643,9,1053,325,1186,240,274,511,23,204,567,228,186,257,268,110,592,77,887,103,769,154,683,73,1223,228,479,521,281,789,1046,145,1084,883,557,602,662,637,628,600,105,126,440,193,1198,484,482,758,997,561,490,466,136,546,736,546,956,525]
foldcommands = [('x',655),('y',447),('x',327),('y',223),('x',163),('y',111),('x',81),('y',55),('x',40),('y',27),('y',13),('y',6)]