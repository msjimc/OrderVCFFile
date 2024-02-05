# Order VCF files by chromosome and position

The application will read a single VCF file, sort the chromosomes in the 'Contig' header section (i.e "##contig=<ID=chr1,length=249250621>") by the chromosome number in a numeric and not alphabetic manner.  

* The X, Y and MT chromosomes are sorted as 1,000,000, 1,000,001 and 1,000,002 respectively and so appear at the end of the list. Contigs with names similar to 'chr6_ssto_hap7' and 'chr6_mcf_hap5' are placed after chr6 and before chr7 in alphabetical order.  

* Those with a name like 'chrUn_gl000233' are given a number of 1,000,003 and placed at the very end of the list.  

* The presence of the 'chr' prefix is optional.  

* The rest of the header file is saved in the same order as the original file.

* The variants are then saved to collections based on their chromosome name and sorted by position. They are then saved by chromosome in the same order as the header with the variants on the chromosome ordered by position. This means the chr 2 variants appear after chr1 and before chr3 rather than after chr19 as seen when sorted alphabetically.

### Contig/reference naming constraints

To identify the chromosome name by number, the sequence name must conform to a suitable structure. 
* In the VCF file header section the name must start with the prefix "___##contig=<ID=___".
* The name may or may not start with a "___chr___".
* The chromosome number most follow either a "___=___" or "___=chr___" and end immediately before either a "___,___" or "___\____". i.e
* * "##contig=<ID=chr1,length=249250621>"
* * "##contig=<ID=1,length=249250621>"
* * "##contig=<ID=chr6_mann_hap4,length=4683263>"
* * "##contig=<ID=6_mann_hap4,length=4683263>"
* * "##contig=<ID=chr19_gl000209_random,length=159169>"
* * "##contig=<ID=19_gl000209_random,length=159169>"

* The sex and mitochondrial chromosomes start with either an upper or lower case letter with or without the "___chr___":
* * ##contig=<ID=chrM,length=16571>
* * ##contig=<ID=X,length=155270560>
* * ##contig=<ID=chry,length=59373566>

* unplaced contigs have the same structure as the sex and mitochondrial chromosomes except they start with a "___U___"

* * ##contig=<ID=chrUn_gl000218,length=161147>
* * ##contig=<ID=Un_gl000218,length=161147>

The order of the contigs in the file is the same as the order the variants are written in: a contig does not necessarily have any associated variants, but a variant must have an associated contig header row.
A fragment of header is shown below to highlight the final order.


##contig=<ID=chr1,length=249250621>     
##contig=<ID=chr1_gl000191_random,length=106433>     
##contig=<ID=chr1_gl000192_random,length=547496>     
##contig=<ID=chr2,length=243199373>     
##contig=<ID=chr3,length=198022430>     
##contig=<ID=chr4,length=191154276>     
##contig=<ID=chr4_ctg9_hap1,length=590426>     
##contig=<ID=chr4_gl000193_random,length=189789>     
##contig=<ID=chr4_gl000194_random,length=191469>     
##contig=<ID=chr5,length=180915260>     
##contig=<ID=chr6,length=171115067>     
##contig=<ID=chr6_apd_hap1,length=4622290>     
##contig=<ID=chr6_cox_hap2,length=4795371>     
##contig=<ID=chr6_dbb_hap3,length=4610396>     
##contig=<ID=chr6_mann_hap4,length=4683263>     
##contig=<ID=chr6_mcf_hap5,length=4833398>     
##contig=<ID=chr6_qbl_hap6,length=4611984>     
##contig=<ID=chr6_ssto_hap7,length=4928567>     
##contig=<ID=chr7,length=159138663>     
##contig=<ID=chr7_gl000195_random,length=182896>     
##contig=<ID=chr8,length=146364022>     
##contig=<ID=chr8_gl000196_random,length=38914>     
##contig=<ID=chr8_gl000197_random,length=37175>     
##contig=<ID=chr9,length=141213431>     
##contig=<ID=chr9_gl000198_random,length=90085>     
##contig=<ID=chr9_gl000199_random,length=169874>     
##contig=<ID=chr9_gl000200_random,length=187035>     
##contig=<ID=chr9_gl000201_random,length=36148>     
##contig=<ID=chr10,length=135534747>     
##contig=<ID=chr11,length=135006516>     
##contig=<ID=chr11_gl000202_random,length=40103>     
##contig=<ID=chr12,length=133851895>     
##contig=<ID=chr13,length=115169878>     
##contig=<ID=chr14,length=107349540>     
##contig=<ID=chr15,length=102531392>     
##contig=<ID=chr16,length=90354753>     
##contig=<ID=chr17,length=81195210>     
##contig=<ID=chr17_ctg5_hap1,length=1680828>     
##contig=<ID=chr17_gl000203_random,length=37498>     
##contig=<ID=chr17_gl000204_random,length=81310>     
##contig=<ID=chr17_gl000205_random,length=174588>     
##contig=<ID=chr17_gl000206_random,length=41001>     
##contig=<ID=chr18,length=78077248>     
##contig=<ID=chr18_gl000207_random,length=4262>     
##contig=<ID=chr19,length=59128983>     
##contig=<ID=chr19_gl000208_random,length=92689>     
##contig=<ID=chr19_gl000209_random,length=159169>     
##contig=<ID=chr20,length=63025520>     
##contig=<ID=chr21,length=48129895>     
##contig=<ID=chr21_gl000210_random,length=27682>     
##contig=<ID=chr22,length=51304566>     
##contig=<ID=chrX,length=155270560>     
##contig=<ID=chrY,length=59373566>     
##contig=<ID=chrM,length=16571>     
##contig=<ID=chrUn_gl000211,length=166566>     
##contig=<ID=chrUn_gl000212,length=186858>     
##contig=<ID=chrUn_gl000213,length=164239>     
##contig=<ID=chrUn_gl000214,length=137718>     
