# Order VCF files by chromosome and position

The application will read a single VCF file, sort the chromosomes in the 'Contig' header section (i.e "##contig=<ID=chr1,length=249250621>") by the chromosome number in a numeric and not alphabetic manner.  

* The X, Y and MT chromosomes are sorted as 1,000,000, 1,000,001 and 1,000,002 respectively and so appear at the end of the list. Contigs with names similar to 'chr6_ssto_hap7' and 'chr6_mcf_hap5' are placed after chr6 and before chr7 in alphabetical order.  

* Those with a name like 'chrUn_gl000233' are given a number of 1,000,003 and placed at the very end of the list.  

* The presence of the 'chr' prefix is optional.  

* The rest of the header file is saved in the same order as the original file.

* The variants are then saved to collections based on their chromosome name and sorted by position. They are then saved by chromosome in the same order as the header with the variants on the chromosome ordered by position. This means the chr 2 variants appear after chr1 and before chr3 rather than after chr19 as seen when sorted alphabetically.
