import System.IO
import Control.Monad
import Data.Char
import Data.List
import System.Win32 (COORD(y, x))



main = print (output1)

output1 = sort (map length ((group . sort) finalstring))

finalstring = repeatInsertion 10 startstring
startstring = "CHBBKPHCPHPOKNSNCOVB"

inserters = [("SP","K"),("BB","H"),("BH","S"),("BS","H"),("PN","P"),("OB","S"),("ON","C"),("HK","K"),("BN","V"),("OH","F"),("OF","C"),("SN","N"),("PF","H"),("CF","F"),("HN","S"),("SK","F"),("SS","C"),("HH","C"),("SO","B"),("FS","P"),("CB","V"),("NK","F"),("KK","P"),("VN","H"),("KF","K"),("PS","B"),("HP","B"),("NP","P"),("OO","B"),("FB","V"),("PO","B"),("CN","O"),("HC","B"),("NN","V"),("FV","F"),("BK","K"),("VC","K"),("KV","V"),("VF","V"),("FO","O"),("FK","B"),("HS","C"),("OV","F"),("PK","F"),("VV","S"),("NH","K"),("SH","H"),("VB","H"),("NF","P"),("OK","B"),("FH","F"),("CO","V"),("BC","K"),("PP","S"),("OP","V"),("VO","C"),("NC","F"),("PB","F"),("KO","O"),("BF","C"),("VS","K"),("KN","P"),("BP","F"),("KS","V"),("SB","H"),("CH","N"),("HF","O"),("CV","P"),("NB","V"),("FF","H"),("OS","S"),("CS","S"),("KC","F"),("NS","N"),("NV","O"),("SV","V"),("BO","V"),("BV","V"),("CC","F"),("CK","H"),("KP","C"),("KH","H"),("KB","F"),("PH","P"),("VP","P"),("OC","F"),("FP","N"),("HV","P"),("HB","H"),("PC","N"),("VK","H"),("HO","V"),("CP","F"),("SF","N"),("FC","P"),("NO","K"),("VH","S"),("FN","F"),("PV","O"),("SC","N")]

absDiff :: Num a => a -> a -> a
absDiff n = abs . (n-)

findInserter :: String -> [(String,String)] -> String
findInserter (p1:p2) ((c1:c2,output):xs) 
    | p1 == c1 && p2 == c2 = output
    | otherwise = findInserter (p1:p2) xs
findInserter _ _ = []

insertPolymers :: String -> String
insertPolymers (x:[y]) = [x] ++ (findInserter [x,y] inserters) ++ [y]
insertPolymers (x:y:xs) = [x] ++ (findInserter [x,y] inserters) ++ (insertPolymers (y:xs))
insertPolymers [x] = [x]
insertPolymers [] = []

repeatInsertion :: Int -> String -> String
repeatInsertion 0 finalstring = finalstring
repeatInsertion x currentstring = repeatInsertion (x-1) (insertPolymers currentstring)

--part 2

findInserter2 :: (String,String) -> [(String,String)] -> String
findInserter2 searchstring ((c1,_):xs) 
    | fst searchstring == c1 = c1
    | otherwise = findInserter2 searchstring xs
findInserter2 _ _ = []

inserterToPair :: (String,String) -> (String,Int)
inserterToPair x = (findInserter2 x inserters,0)

paircounter = map inserterToPair inserters

initialcounter = initialisecounter startstring initialcounter

initialisecounter :: String -> [(String,Int)] -> [(String,Int)]
initialisecounter (x:[y]) currentlist = incrementcounter [x,y] currentlist
initialisecounter (x:y:xs) currentlist = initialisecounter xs (incrementcounter [x,y] currentlist)
initialisecounter [x] currentlist = currentlist
initialisecounter [] currentlist = currentlist

incrementcounter :: String -> [(String,Int)] -> [(String,Int)]
incrementcounter pair list = map (findandincrement pair) list

findandincrement :: String -> (String,Int) -> (String,Int)
findandincrement search (find,x)
    | search == find = (find, x+1)
    | otherwise = (find,x)