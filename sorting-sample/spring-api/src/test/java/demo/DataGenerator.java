package demo;

public class DataGenerator {

    public static void main(String[] args) {
        int size = 10000;
        StringBuilder arrayBuilder = new StringBuilder("[ ");

        for (int i = 0; i < size; i++) {
            arrayBuilder.append((int) ((Math.random() * size) + 1)).append(",");
        }

        String unsortedArray = arrayBuilder.substring(0, arrayBuilder.length() - 1);

        unsortedArray += " ]";
        System.out.println(unsortedArray);
    }
}
