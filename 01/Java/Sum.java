public class Sum {
    public static void main(String[] args) {
        int sum = 0;
        for (int i = 0; i < args.length; i++) {
            String spl[];
            if (args[i].trim().length() != 0) {
                spl = args[i].trim().split("\\s+");
            } else {
                spl = new String[0];
            }
            for (int j = 0; j < spl.length; j++) {
                sum += Integer.parseInt(spl[j]);
            }
        }
        System.out.println(sum);
    }
}