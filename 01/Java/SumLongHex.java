public class SumLongHex {
    public static void main(String[] args) {
        long sum = 0;
        for (int i = 0; i < args.length; i++) {
            String spl[];
            if (args[i].length() != 0) {
                spl = args[i].split("\\p{javaWhitespace}+");
            } else {
                spl = new String[0];
            }
            for (int j = 0; j < spl.length; j++) {
                if (!spl[j].isEmpty()) {
                    spl[j] = spl[j].toLowerCase();
                    if (spl[j].startsWith("0x")) {
                        sum += Long.parseUnsignedLong(spl[j].substring(2, spl[j].length()), 16);
                    } else {
                        sum += Long.parseLong(spl[j]);
                    }
                }
            }
        }
        System.out.println(sum);
    }
}